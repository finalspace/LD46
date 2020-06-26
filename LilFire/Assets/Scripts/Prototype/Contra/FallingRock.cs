using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : Bullet
{
    public FallingRockMovement movement;
    public AutoRotation rotationAnimation;

    private void OnEnable()
    {
        movement.isSimulating = true;
        rotationAnimation.enabled = true;
    }

    private void OnDisable()
    {
        movement.isSimulating = false;
        rotationAnimation.enabled = false;
    }
}
