using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public bool destroyAfterHit = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        Damage();
    }

    public void Damage()
    {
        Player.Instance.Damage();
        if (destroyAfterHit)
            Destroy(gameObject);
    }
}
