using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : Bullet
{
    public FallingRockMovement movement;
    public AutoRotation rotationAnimation;

    protected override void OnEnable()
    {
        base.OnEnable();
        movement.isSimulating = true;
        rotationAnimation.enabled = true;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        movement.isSimulating = false;
        rotationAnimation.enabled = false;
    }
}
