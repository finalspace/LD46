using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour
{
    public Transform root;
    public GameObject bulletPrefab;
    public float angleFrom = 0;
    public float angleTo = 0;
    public float speedFrom = 1.0f;
    public float speedTo = 2.0f;
    public float coolDownMin = 1.0f;
    public float coolDownMax = 3.0f;

    private float cooldown;

    public long lastTime;

    private void Start()
    {
        ResetCoolDown();
        lastTime = DateTimeUtil.GetUnixTime();
    }

    private void Update()
    {
        if (DateTimeUtil.SecondsElapse(lastTime) > cooldown)
        {
            Spawn();
            ResetCoolDown();
            lastTime = DateTimeUtil.GetUnixTime();
        }
    }

    public void Spawn()
    {
        float angle = Random.Range(angleFrom, angleTo);
        float speed = Random.Range(speedFrom, speedTo);
        Vector3 direction = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0);
        Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        bullet.transform.position = root.position;
        bullet.Init(direction * speed);
    }

    private void ResetCoolDown()
    {
        cooldown = Random.Range(coolDownMin, coolDownMax);
    }

}
