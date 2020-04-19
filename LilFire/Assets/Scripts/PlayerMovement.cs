﻿using UnityEngine;
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

    private Vector2 deltaMovement;
    private float accelerationTimeAirborne = .4f;
	private float accelerationTimeGrounded = .2f;
	private float gravity;
	private float jumpVelocity;
	private Vector3 velocity;
	private float velocityXSmoothing;

    private PlayerCollision playerCollision;
	private Animator anim;

    private bool isDead = false;
	private bool facingRight = true;
	private bool doubleJump = false;
    private bool isRunning = false;
    private bool isOnGround = false;
    private bool foot = false;
    const int maxJumpNum = 1;
	int jumpNum;

    [Header("Aiming Effects")]
    public List<GameObject> aimingDots;
    private bool aiming = false;
    private int NumIterations = 8;
    private Vector3 mousePosition;

    [Header("Skills")]
    //public RangedWeapon rangeWeapon;

    [Header("Visual Effects")]
	public GameObject damageEffect;
	public GameObject footEffect;
	public Animator hurtPanel;
	//private PlayerHealth health;
    public GameObject trailEffect;
    public float startTrailEffectTime;
    private float trailEffectTime;

    [Header("Audio Effects")]
	public AudioClip landing;
    private AudioSource source;

    void Start() {
		source = GetComponent<AudioSource>();
		//health = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerHealth>();
		anim = GetComponent<Animator>();
        playerCollision = GetComponent<PlayerCollision> ();
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        //health.noDam = false;

        jumpNum = maxJumpNum;
	}

	void Update() 
    {
        HandleInput();
	}

    private void FixedUpdate()
    {
        if (aiming)
            DrawTrajectory();
        UpdateMovement();

        // detects when on the ground
        if (playerCollision.collisions.below)
        {
            if (foot == true)
            {
                if (landing != null)
                {
                    source.clip = landing;
                    source.Play();
                }
                //anim.SetBool("isJumping", false);
                foot = false;
                Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.6f);
                Instantiate(footEffect, pos, Quaternion.identity);
            }
            //anim.SetBool("isJumping", false);
            velocity.y = 0;
            deltaMovement.x = 0;
            doubleJump = false;
            jumpNum = maxJumpNum;
        }
        else
        {
            //anim.SetBool("isJumping", true);
            foot = true;
        }

        if (playerCollision.collisions.above)
        {
            velocity.y = 0;
            deltaMovement.x /= 2.0f;
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
            //deltaMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(mousePosition, transform.position) > 1.0f)
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
                if (Vector2.Distance(mousePosition, transform.position) > 0.5f)
                    Launch();
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
        float dt = Time.fixedDeltaTime * 5;
        Vector3 vel = ComputeInitialVelocity();
        Vector3 position = transform.position;
        for (int i = 0; i < NumIterations; ++i)
        {
            vel.y += gravity * dt;
            position += vel * dt;
            aimingDots[i].transform.position = position;
        }
    }


    private Vector3 ComputeInitialVelocity()
    {
        Vector3 diff = transform.position - mousePosition;
        diff.x = Mathf.Clamp(diff.x, -1.5f, 1.5f);
        diff.y = Mathf.Clamp(diff.y, -0.8f, 0.8f);
        diff.x *= 5.0f;
        diff.y *= 20.0f;
        return diff;
    }

    private void SetAiming(bool val)
    {
        if (aiming == val)
            return;
        aiming = val;
        for (int i = 0; i < aimingDots.Count; i++)
        {
            if (aiming) aimingDots[i].transform.position = transform.position;
            aimingDots[i].SetActive(aiming);
        }
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
        foot = true;
        velocity.y = jumpVelocity;
    }

    private void Launch()
    {
        foot = true;
        velocity = ComputeInitialVelocity();
        deltaMovement.x = velocity.x;
        SetAiming(false);
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
