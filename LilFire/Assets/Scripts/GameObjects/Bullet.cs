using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform visualRoot;
    public Vector3 velocity;
    public bool destroyAfterHit = false;
    public bool noDamage = false;

    [Header("Homing")]
    public bool homing = false;
    public Transform target;
    public float power = 0.05f;
    public float trackingTime = -1;

    private float speed;

    private void Start()
    {
        if (trackingTime < 0)
            trackingTime = float.MaxValue;
    }

    public void Init(Vector3 vel)
	{
		velocity = vel;
        speed = velocity.magnitude;
    }

    public void Init(Vector3 vel, Transform t)
    {
        target = t;
        Init(vel);
    }

    private void Update()
    {
        if (homing && target != null)
        {
            velocity += (target.position - transform.position).normalized * power;
            velocity = velocity.normalized * speed;
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            visualRoot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            trackingTime -= Time.deltaTime;
            if (trackingTime < 0)
                homing = false;
        }
        transform.Translate(velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (noDamage) return;

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
