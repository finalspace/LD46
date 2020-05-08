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
    private float accelerationTimeAirborne = .9f;
	private float accelerationTimeGrounded = .2f;
	private float gravity;
	private float jumpVelocity;
	private Vector2 velocity;
	private float velocityXSmoothing;
    private float targetVelocityX;

    private PlayerCollision playerCollision;
	private Animator anim;

    private bool isDead = false;
	private bool facingRight = true;
    private bool doubleJump = false;
    private bool isRunning = false;
    private bool isOnGround = false;
    private bool isJumping = true;
    //private bool isFalling = false;
    const int maxJumpNum = 2;
    private int jumpNum;
    private bool powerMode = false;

    private Transform parentTransform;
    private Vector2 parentLastPosition;
    private Vector2 parentVelocity;

    [Header("Aiming Effects")]
    public GameObject aimingRoot;
    public List<GameObject> aimingDots;
    public bool aiming = false;
    private int NumIterations = 13;
    //private float aimingLoopRange = 10;
    private float aimingTime = 0;
    private Vector3 camFirstPos;
    private Vector3 mouseFirstPos;
    private Vector3 mousePosition;
    private Vector3 startPosOffset = new Vector3(0, 0.5f, 0);
    private float velXSmoothingTemp;

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
        jumpNum = 0;

        aimingRoot.transform.SetParent(null);
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

        // on the ground or in the air
        if (playerCollision.collisions.below)
        {
            if (isJumping == true)
            {
                EventManager.Event_PlayerLand();
                isJumping = false;
                Attach(playerCollision.collisions.belowTransform);

                Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.6f);
                Instantiate(footEffect, pos, Quaternion.identity);
                root.rotation = Quaternion.Euler(0, 0, 0);
            }
            velocity.y = 0;
            deltaMovement.x = 0;
            targetVelocityX = 0;
            jumpNum = 0;
            powerMode = false;
        }
        else
        {
            isJumping = true;
            parentTransform = null;

            float ang = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90;
            // ang = Mathf.LerpAngle(transform.eulerAngles.z, ang, Time.deltaTime * rotateSpeed);
            root.rotation = Quaternion.Euler(0, 0, ang);
            Debug.DrawRay(transform.position, velocity * 2, Color.green);
        }

        //when blocked by ceiling
        if (playerCollision.collisions.above)
        {
            velocity.y = 0;
            deltaMovement.x *= 0.8f;
            targetVelocityX *= 0.8f;
        }

        // die if player height goes below the starting level; can update the fatal height as we got
        if (Player.Instance.transform.position.y < PlayerStats.Instance.fatalHeightFalling)
        {
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

        if (!isDead)
        {
            //keyboard control
            //deltaMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetMouseButtonDown(0) && AbleToJump())
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseFirstPos = mousePosition;

                SetAiming(true);
                if (jumpNum == maxJumpNum - 1)
                    TimeManager.Instance.SlowMotion();
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
                TimeManager.Instance.Reset();

                if (Vector2.Distance(mousePosition, mouseFirstPos) > 0.5f)
                    Launch();
                else LaunchFailed();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                //Respawn();
            }
        }
    }


    /// <summary>
    /// Updates the movement using deltaMovement calculated every frame
    /// </summary>
    private void UpdateMovement()
    {
        Flip(deltaMovement);

        // handles moving and physics for jumping
        //float targetVelocityX = deltaMovement.x * moveSpeed;
        //targetVelocityX = deltaMovement.x;
        float accelerationTime = (playerCollision.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTime, Mathf.Infinity, Time.fixedDeltaTime);

        if (!powerMode)
        velocity.y += gravity * Time.fixedDeltaTime;

        if (powerMode)
            velocity *= 0.88f;
        if (velocity.magnitude < 5.0f)
            powerMode = false;

        if (parentTransform != null)
        {
            //velocity += parentVelocity;
        }

        if (isDead)
        {
            playerCollision.MoveIgnoreCollision(velocity * Time.fixedDeltaTime);
            return;
        }

        playerCollision.Move(velocity * Time.fixedDeltaTime);

        isOnGround = playerCollision.collisions.below;

        if (isRunning || !isOnGround)
        {
            //UpdateTrailEffect(); 
        }
    }

    private void DrawTrajectory()
    {
        Vector2 vel = ComputeInitialVelocity();
        Vector2 dotPos = transform.position + startPosOffset;

        aimingTime += Time.fixedDeltaTime;
        float offTime = Mathf.Repeat(aimingTime, 1.0f);
        offTime = offTime / 10f;
        float dt = Time.fixedDeltaTime * 5;

        float targetVx = vel.x / 2;
        vel.x = Mathf.SmoothDamp(vel.x, targetVx, ref velXSmoothingTemp, accelerationTimeAirborne, Mathf.Infinity, offTime);
        vel.y += gravity * offTime;
        dotPos += vel * offTime;
     
        for (int i = 0; i < NumIterations; ++i)
        {
            aimingDots[i].transform.position = dotPos;
            vel.x = Mathf.SmoothDamp(vel.x, targetVx, ref velXSmoothingTemp, accelerationTimeAirborne, Mathf.Infinity, dt);
            vel.y += gravity * dt;
            dotPos += vel * dt;
        }
    }


    private Vector2 ComputeInitialVelocity()
    {
        Vector2 power;
        Vector2 diff = mouseFirstPos + startPosOffset - mousePosition;
        float x = Mathf.InverseLerp(0, 6, Mathf.Abs(diff.x));
        //x = Mathf.Sqrt(x);
        x = Mathf.Sin(x * Mathf.PI / 2);
        power.x = Mathf.Lerp(0, 15f, x) * Mathf.Sign(diff.x);

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

        aimingRoot.SetActive(val);
        if (!aiming)
        {
            for (int i = 0; i < aimingDots.Count; i++)
            {
                aimingDots[i].transform.position = transform.position;
            }
            aimingTime = 0;
        }

        if (aiming)
            Player.Instance.animator.PlaySquish();
        else
            Player.Instance.animator.PlayIdle();
    }

    private bool AbleToJump()
    {
        return (jumpNum < maxJumpNum);
    }


   /*****************************************
    * 
    * Actions
    * 
    *****************************************/

    public void Reset()
    {
        root.rotation = Quaternion.Euler(0, 0, 0);
        velocity = Vector2.zero;
        SetAiming(false);
        Detach();
    }
      
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


    private void Launch()
    {
        float energy = PlayerStats.Instance.energy;
        if (energy < 3) return;

        isJumping = true;
        jumpNum++;
        powerMode = (jumpNum == maxJumpNum);
        Detach();

        velocity = ComputeInitialVelocity();
        float power = velocity.magnitude / 3;
        float adjustedPower = Mathf.Min(power, energy);
        velocity = velocity * (adjustedPower / power);  //adjusted velocity

        if (powerMode)
            velocity *= 2.5f;

        //deltaMovement.x = velocity.x;
        targetVelocityX = velocity.x / 2;

        EventManager.Event_PlayerJump(adjustedPower);
    }

    private void LaunchFailed()
    {
        EventManager.Event_PlayerJumpFail();
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

    public void Attach(Transform trans)
    {
        parentTransform = trans;
        parentLastPosition = parentTransform.position;
        transform.SetParent(trans);
    }

    public void Detach()
    {
        parentTransform = null;
        transform.SetParent(null);
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
