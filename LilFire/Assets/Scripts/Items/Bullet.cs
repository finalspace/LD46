using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;

    public void Init(Vector3 vel)
	{
		velocity = vel;
	}

    private void FixedUpdate()
    {
        transform.Translate(velocity * Time.fixedDeltaTime);
    }
}
