using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DashDamage : MonoBehaviour
{
    public UnityEvent triggerEvent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        if (Player.Instance.playerMovement.isDashing)
            triggerEvent.Invoke();
    }
}
