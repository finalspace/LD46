using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public bool destroyAfterHit = false;

    public void Init(Vector3 vel)
	{
		velocity = vel;
	}

    private void FixedUpdate()
    {
        transform.Translate(velocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;

        Damage();
    }

    public void Damage()
    {
        Player.Instance.Die();
        if (destroyAfterHit)
            Destroy(gameObject);
    }
}
