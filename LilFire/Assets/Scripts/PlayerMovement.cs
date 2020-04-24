using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent (typeof (PlayerCollision))]
//public class PlayerMovement : SingletonBehaviour<Player>
public class PlayerMovement : MonoBehaviour
{

	[Header ("Moving and Jumping")]
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float moveSpeed = 6;
    public Transform root;

    private Vector2 deltaMovement;
    private float accelerationTimeAirborne = .4f;
	private float accelerationTimeGrounded = .2f;
	private float gravity;
	private float jumpVelocity;
	private Vector2 velocity;
	private float velocityXSmoothing;

    private PlayerCollision playerCollision;
	private Animator anim;

    private bool isDead = false;
	private bool facingRight = true;
    private bool doubleJump = false;
    private bool isRunning = false;
    private bool isOnGround = false;
    private bool isJumping = false;
    //private bool isFalling = false;
    const int maxJumpNum = 1;
    int jumpNum;

    [Header("Aiming Effects")]
    public List<GameObject> aimingDots;
    public bool aiming = false;
    private int NumIterations = 8;
    //private float aimingLoopRange = 10;
    private float aimingTime = 0;
    private Vector3 mousePosition;

    //[Header("Skills")]
    //public RangedWeapon rangeWeapon;

    [Header("Visual Effects")]
	public GameObject damageEffect;
	public GameObject footEffect;
	public Animator hurtPanel;
    public GameObject trailEffect;
    public float startTrailEffectTime;
    private float trailEffectTime;

    void Start() {
		anim = GetComponent<Animator>();
        playerCollision = GetComponent<PlayerCollision> ();
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        jumpNum = maxJumpNum;
	}

	void Update() 
    {
        HandleInput();
        if (aiming)
            DrawTrajectory();
    }

    private void FixedUpdate()
    {
        UpdateMovement();

        // detects when on the ground
        if (playerCollision.collisions.below)
        {
            if (isJumping == true)
            {
                EventManager.Event_PlayerLand();
                MusicManager.Instance.PlayLand();
                isJumping = false;
                Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.6f);
                Instantiate(footEffect, pos, Quaternion.identity);
                root.rotation = Quaternion.Euler(0, 0, 0);
                Player.Instance.animator.PlayLanding();
            }
            velocity.y = 0;
            deltaMovement.x = 0;
            doubleJump = false;
            jumpNum = maxJumpNum;
        }
        else
        {
            //anim.SetBool("isJumping", true);
            isJumping = true;
            //root.rotation = Quaternion.Euler(0.0f, 0.0f, (Mathf.Repeat(m_phase, 2.0f) < 1.0f ? -25.0f : 25.0f));
            //root.rotation = Quaternion.LookRotation(velocity);

            float ang = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90;
            // ang = Mathf.LerpAngle(transform.eulerAngles.z, ang, Time.deltaTime * rotateSpeed);
            root.rotation = Quaternion.Euler(0, 0, ang);
            Debug.DrawRay(transform.position, velocity * 2, Color.green);
        }

        //when blocked by ceiling
        if (playerCollision.collisions.above)
        {
            velocity.y = 0;
            deltaMovement.x *= 0.9f;
        }

        // die if player height goes below the starting level; can update the fatal height as we got
        if (Player.Instance.transform.position.y < PlayerStats.Instance.fatalHeightFalling)
        {
            //Debug.Log("Player dies from falling");
            Player.Instance.Die();
        }

    }

    /// <summary>
    /// Handles the input. 
    /// calculate deltaMovement used for UpdateMovement
    /// </summary>
    private void HandleInput()
    {
        deltaMovement = Vector2.zero;

        // detects if the player is holding the arrow keys to move
        if (!isDead)
        {
            //keyboard control
            //deltaMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(mousePosition, transform.position) > 2.0f)
                    return;

                SetAiming(true);
            }

            if (Input.GetMouseButton(0))
            {
                if (!aiming) return;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (!aiming) return;

                SetAiming(false);
                if (Vector2.Distance(mousePosition, transform.position) > 0.5f)
                    Launch();
                else LaunchFailed();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                GoToHighestWaypoint();
            }

            // jump and double jump and triple jump
            /*
            if (Input.GetKey(KeyCode.Space) && playerCollision.collisions.below)
            {
                Jump();
            }
            */

            /*
            if (Input.GetKey(KeyCode.L) && playerCollision.collisions.below)
            {
                Launch();
            }
            */
            /*
            if (Input.GetKeyDown(KeyCode.Space) && doubleJump == false && !controller.collisions.below){
                velocity.y = jumpVelocity;
                jumpNum--;
                if(jumpNum <= 0){
                    doubleJump = true;
                }
            } 
            */
        }
    }


    /// <summary>
    /// Updates the movement using deltaMovement calculated every frame
    /// </summary>
    private void UpdateMovement()
    {
        Flip(deltaMovement);

        // handles moving and physics for jumping
        float targetVelocityX = deltaMovement.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (playerCollision.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.fixedDeltaTime;

        if (isDead)
        {
            playerCollision.MoveIgnoreCollision(velocity * Time.fixedDeltaTime);
            return;
        }

        playerCollision.Move(velocity * Time.fixedDeltaTime);
        isRunning = (deltaMovement.x != 0);
        //anim.SetBool("isRunning", isRunning);

        isOnGround = playerCollision.collisions.below;

        if (isRunning || !isOnGround)
        {
            //UpdateTrailEffect(); 
        }
    }

    private void DrawTrajectory()
    {
        aimingTime = aimingTime + Time.fixedDeltaTime;
        float offTime = Mathf.Repeat(aimingTime, 1.0f);
        offTime = offTime / 10f;
        float dt = Time.fixedDeltaTime * 5;
        Vector2 vel = ComputeInitialVelocity();
        Vector2 position = transform.position;
        vel.y += gravity * offTime;
        position += vel * offTime;
     
        for (int i = 1; i < NumIterations; ++i)
        {
            aimingDots[i].transform.position = position;
            vel.y += gravity * dt;
            position += vel * dt;
        }
    }


    private Vector2 ComputeInitialVelocity()
    {
        Vector2 power;
        Vector2 diff = transform.position + new Vector3(0, 0.5f, 0) - mousePosition;
        float x = Mathf.InverseLerp(0, 6, Mathf.Abs(diff.x));
        x = Mathf.Sqrt(x);
        power.x = Mathf.Lerp(0, 10f, x) * Mathf.Sign(diff.x);

        float y = Mathf.InverseLerp(0, 1.5f, Mathf.Abs(diff.y));
        y = Mathf.Sqrt(y);
        power.y = Mathf.Lerp(0, 20f, y) * Mathf.Sign(diff.y);
        return power;
    }

    public void SetAiming(bool val)
    {
        if (aiming == val)
            return;
        aiming = val;

        for (int i = 0; i < aimingDots.Count; i++)
        {
            if (aiming) aimingDots[i].transform.position = transform.position;
            aimingDots[i].SetActive(aiming);
        }

        if (aiming)
            Player.Instance.animator.PlaySquish();
        else
            Player.Instance.animator.PlayIdle();
    }


   /*****************************************
    * 
    * Actions
    * 
    *****************************************/

      
    public void Dead()
    {
        if (isDead)
            return;

        PlayerUtils.PlayerDeadOccur();
        velocity = new Vector2(-jumpVelocity / 8, jumpVelocity / 2);
        playerCollision.collisions.below = false;
        isDead = true;
    }

    private void Jump()
    {
        isJumping = true;
        velocity.y = jumpVelocity;
    }

    public void GoToHighestWaypoint()
    {
        BoardManager brd = BoardManager.Instance;

        Player.Instance.gameObject.SetActive(false);

        // put player a little higher than achieved waypoint or will fall through
        Player.Instance.transform.position = brd.HighestWaypoint() + 1.3f * Vector3.up;
        velocity = Vector2.zero;
        Player.Instance.gameObject.SetActive(true);
        Player.Instance.animator.PlayIdle();
    }

    private void Launch()
    {
        float energy = PlayerStats.Instance.energy;
        if (energy < 3) return;

        isJumping = true;
        velocity = ComputeInitialVelocity();
        float power = velocity.magnitude / 3;
        float adjustedPower = Mathf.Min(power, energy);
        velocity = velocity * (adjustedPower / power);  //adjusted velocity

        deltaMovement.x = velocity.x;

        Debug.Log(power);
        PlayerStats.Instance.UpdateEnergy(-adjustedPower);
        MusicManager.Instance.PlayJump();
        Player.Instance.animator.PlayJump();
    }

    private void LaunchFailed()
    {
        Player.Instance.animator.PlayIdle();
    }

    private void Attack()
    { 
    }

    private void AttackMelee()
    { 
    }

    private void AttackRange()
    {
    }

    void UpdateTrailEffect()
    {
        if (trailEffectTime <= 0)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y - 1f);
            Instantiate(trailEffect, pos, Quaternion.identity);
            trailEffectTime = startTrailEffectTime;
        }
        else
        {
            trailEffectTime -= Time.deltaTime;
        }
    }


	// flip the character so he is facing the direction he is moving in
	void Flip(Vector2 input){
		
		if(input.x > 0 && facingRight == false || input.x < 0 && facingRight == true){
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	public void Damage(){
        if (hurtPanel != null)
            hurtPanel.SetTrigger("Hurt");
        if (damageEffect != null)
            Instantiate(damageEffect, transform.position, Quaternion.identity);
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }
    }

    public bool IsDead()
    {
        return isDead;
    }



}
