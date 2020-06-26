using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent (typeof (PlayerCollision))]
public class FallingBugMovement : MonoBehaviour
{
	[Header ("Moving and Jumping")]
    public PlayerCollision playerCollision;
	public float gravity;
	public float bounceVelocity;
	private Vector2 velocity;
    private float targetVelocityX;  //don't set x velocity directly
    private float accelerationTimeAirborne = .9f;
    private float velocityXSmoothing;
    private float velXSmoothingTemp;

    private Collider2D ignoreCollider;

    [Header("Status")]
    public bool isSimulating = true;
    private bool isJumping = false;

    [Header("Visual Effects")]
	public GameObject footEffect;

    void Start() {
        playerCollision = GetComponent<PlayerCollision> ();
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
        //------------------------ Update Velocity ---------------------------------------
        //------------------------                 ---------------------------------------
        float accelerationTime = accelerationTimeAirborne;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTime, Mathf.Infinity, Time.fixedDeltaTime);
        velocity.y += gravity * Time.fixedDeltaTime;

        //------------------------ Update Position ---------------------------------------
        //------------------------                 ---------------------------------------
        playerCollision.MoveIgnoreCollision(velocity * Time.fixedDeltaTime, ignoreCollider);
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
                Land(playerCollision.collisions.belowCollider);
            }
        }
        else
        {
            isJumping = true;
        }
    }

    public void Launch(Vector2 vel)
    {
        isJumping = true;
        velocity = vel;
        targetVelocityX = velocity.x / 2;

        EventManager.Event_PlayerJump(velocity);
    }


    public void Land(Collider2D groundCollider)
    {
        isJumping = false;
        ignoreCollider = groundCollider;

        Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.6f);
        if (footEffect != null)
            Instantiate(footEffect, pos, Quaternion.identity);

        velocity = new Vector2(0, bounceVelocity);
    }

}
