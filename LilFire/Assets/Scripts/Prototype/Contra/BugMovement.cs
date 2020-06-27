using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

[RequireComponent (typeof (PlayerCollision))]
public class BugMovement : SimpleMovement
{
    [Header("BugMovement")]
    [Header("----------------------------------")]
    public float bounceVelocity;

    private bool landed = false;
    private int bounceCount = 2;

    public override void Land(Collider2D groundCollider)
    {
        base.Land(groundCollider);

        if (!landed)
        {
            landed = true;
            Vector3 diff = Player.Instance.transform.position - transform.position;
            targetVelocityX = Mathf.Sign(diff.x) * 2;
            velocity = new Vector2(targetVelocityX / 2, bounceVelocity);
        }
        else
        {
            bounceCount--;
            if (bounceCount <= 0)
                ignoreCollider = groundCollider;

            velocity.y = bounceVelocity;
        }
    }

    public override void OnGround()
    {
    }

}
