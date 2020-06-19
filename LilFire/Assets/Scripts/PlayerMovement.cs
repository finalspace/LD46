using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent (typeof (PlayerCollision))]
public class PlayerMovement : MonoBehaviour
{
	[Header ("Moving and Jumping")]
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float moveSpeed = 6;
    public Transform root;    //view root

    public PlayerCollision playerCollision;
    private Vector2 deltaMovement;
    private float accelerationTimeAirborne = .9f;
	private float accelerationTimeGrounded = .2f;
	private float gravity;
	private float jumpVelocity;
	private Vector2 velocity;
    private float targetVelocityX;  //don't set x velocity directly

    private float velocityXSmoothing;
    private float velXSmoothingTemp;

    [Header("Status")]
    private bool isSimulating = true;
    private bool isDead = false;
	private bool facingRight = true;
    private bool doubleJump = false;
    private bool isRunning = false;
    public bool isOnGround = false;
    public bool isJumping = true;
    //private bool isOnRope = false;
    const int maxJumpNum = 1;
    private int jumpNum;
    private bool dashing = false;
    private bool dashReady = false;
    private Vector2 parentVelocity;

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
        playerCollision = GetComponent<PlayerCollision> ();
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
        gravity *= 1;
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        jumpNum = maxJumpNum;
        dashReady = false;
    }

    private void FixedUpdate()
    {
        if (!isSimulating) return;

        SimulateMovement();
        HandlePhysics();
    }

    /// <summary>
    /// Update velocity and simulate movement
    /// Based on Time (velocity accumulation, position change)
    /// Physics data ready after this step
    /// </summary>
    private void SimulateMovement()
    {
        //Flip(deltaMovement);

        //------------------------ Update Velocity ---------------------------------------
        //------------------------                 ---------------------------------------
        //float targetVelocityX = deltaMovement.x * moveSpeed;  //keyboard direct control
        float accelerationTime = isOnGround ? accelerationTimeGrounded : accelerationTimeAirborne;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTime, Mathf.Infinity, Time.fixedDeltaTime);
        //only apply gravity when not on the ground, and not dashing
        velocity.y += (dashing ? 0 : gravity) * Time.fixedDeltaTime;

        if (dashing)
        {
            velocity *= 0.88f;
            if (velocity.magnitude < 5.0f)
                dashing = false;
        }

        //------------------------ Update Position ---------------------------------------
        //------------------------                 ---------------------------------------
        playerCollision.Move(velocity * Time.fixedDeltaTime);  //move and update physics status based on new position
    }

    /// <summary>
    /// Handle physics after movement
    /// update velocity and position
    /// Based on physics
    ///
    /// in this case, position physics is already handled in SimulateMovement();
    /// </summary>
    private void HandlePhysics()
    {
        //------------------------ Update Velocity ---------------------------------------
        //------------------------                 -------------------------------------
        if (playerCollision.collisions.below)
        {
            if (isJumping == true)
            {
                Land(playerCollision.collisions.belowTransform);
            }
            //OnGround();
        }
        else
        {
            isJumping = true;
            float ang = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90;
            //ang = Mathf.LerpAngle(transform.eulerAngles.z, ang, Time.deltaTime * rotateSpeed);
            //root.rotation = Quaternion.Euler(0, 0, ang);
            Debug.DrawRay(transform.position, velocity, Color.green);
        }

        //when blocked by ceiling
        if (playerCollision.collisions.above)
        {
            velocity.y = -velocity.y * 0.3f;
            velocity.x *= 0.8f;
            targetVelocityX *= 0.8f;
        }

        //side wall
        if (playerCollision.collisions.left || playerCollision.collisions.right)
        {
            float speed = Mathf.Max(1f, Mathf.Abs(velocity.x));
            velocity.x = Mathf.Sign(-velocity.x) * speed * 0.3f;
        }

        //------------------------ Update Status ---------------------------------------
        //------------------------                 -------------------------------------
        isOnGround = playerCollision.collisions.below;
        isJumping = !isOnGround;

        //------------------------ Update View -------------------------------------
        //------------------------             -------------------------------------
        if (isRunning || !isOnGround)
        {
            //UpdateTrailEffect(); 
        }
    }

    public Vector2[] GetTrajectory(Vector2 startPos, Vector2 vel, float aimingTime)
    {
        int aimingDotsCount = 7;
        Vector2[] positions = new Vector2[aimingDotsCount];
        Vector2 dotPos = startPos;

        aimingTime += Time.fixedDeltaTime;
        float offTime = Mathf.Repeat(aimingTime, 1.0f);
        offTime = offTime / 10f;
        float dt = Time.fixedDeltaTime * 5;

        float targetVx = vel.x / 2;
        vel.x = Mathf.SmoothDamp(vel.x, targetVx, ref velXSmoothingTemp, accelerationTimeAirborne, Mathf.Infinity, offTime);
        vel.y += gravity * offTime;
        dotPos += vel * offTime;

        for (int i = 0; i < aimingDotsCount; ++i)
        {
            positions[i] = dotPos;
            vel.x = Mathf.SmoothDamp(vel.x, targetVx, ref velXSmoothingTemp, accelerationTimeAirborne, Mathf.Infinity, dt);
            vel.y += gravity * dt;
            dotPos += vel * dt;
        }

        return positions;
    }

    public bool AbleToJump()
    {
        return (jumpNum > 0);
    }

    /*
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
        }
    }
    */

    /*****************************************
     * 
     * Actions
     * 
     *****************************************/
    private void Jump()
    {
        isJumping = true;
        velocity.y = jumpVelocity;
    }

    public void Land(Transform gound)
    {
        EventManager.Event_PlayerLand();
        isJumping = false;
        //velocity.y = Mathf.Abs(velocity.y * 0.3f);
        //Attach(gound);

        Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.6f);
        if (footEffect != null)
            Instantiate(footEffect, pos, Quaternion.identity);
        root.rotation = Quaternion.Euler(0, 0, 0);

        OnGround();
    }

    public void OnGround()
    {
        velocity.y = 0;
        velocity.x = 0;
        targetVelocityX = 0;
        jumpNum = maxJumpNum;
        dashing = false;
        dashReady = false;
    }

    public void Launch(Vector2 vel)
    {
        float energy = PlayerStats.Instance.energy;
        if (energy < 3) return;

        isJumping = true;
        jumpNum--;
        dashing = dashReady;
        Detach();

        velocity = vel;
        float power = velocity.magnitude / 3;
        float adjustedPower = Mathf.Min(power, energy);
        velocity = velocity * (adjustedPower / power);  //adjusted velocity

        if (dashing)
            velocity *= 2.5f;

        targetVelocityX = velocity.x / 2;

        EventManager.Event_PlayerJump(velocity);
    }

    public void LaunchFailed()
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
        transform.SetParent(trans, true);
    }

    public void Detach()
    {
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

    /*****************************************
     * 
     * Status
     * 
     *****************************************/
    public void StartSimulation()
    {
        isSimulating = true;

        //rotation might have been modified when out of control
        //update root rotation instead to reflect the change
        root.localRotation = transform.rotation;
        transform.rotation = Quaternion.identity;
    }

    public void StopSimulation()
    {
        isSimulating = false;
        Reset();
    }

    public void Reset()
    {
        root.rotation = Quaternion.Euler(0, 0, 0);
        velocity = Vector2.zero;
        Detach();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public Vector3 GetVelocity()
    {
        return velocity;
    }



}
