using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DashDamage : SimpleTrigger
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        if (Player.Instance.playerMovement.isDashing)
            base.OnTriggerEnter2D(other);
    }
}
