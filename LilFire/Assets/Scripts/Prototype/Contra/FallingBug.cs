using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBug : Bullet
{
    public SimpleMovement movement;
    public AutoRotation rotationAnimation;

    private bool landed = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        movement.isSimulating = true;
        rotationAnimation.enabled = true;
        movement.landEvent.AddListener(OnLand);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        movement.isSimulating = false;
        rotationAnimation.enabled = false;
        movement.landEvent.RemoveListener(OnLand);
    }

    public override void Init(Vector3 vel)
    {
        movement.velocity = vel;
        movement.targetVelocityX = vel.x / 2;
        rotationAnimation.SetSpeed(-200 * Mathf.Sign(vel.x));
    }

    public override void Init(Vector3 vel, Transform t)
    {
        Init(vel);
    }

    public void OnLand(Collider2D groundCollider)
    {
        if (landed) return;

        landed = true;
        Vector3 diff = Player.Instance.transform.position - transform.position;
        rotationAnimation.SetSpeed(-200 * Mathf.Sign(diff.x));
    }
}
