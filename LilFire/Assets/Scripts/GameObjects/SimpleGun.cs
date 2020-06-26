﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour
{
    public Transform fireRoot;
    public GameObject bulletPrefab;
    public bool local = false;
    public float angleFrom = 0;
    public float angleTo = 0;
    public float speedFrom = 1.0f;
    public float speedTo = 2.0f;
    public float coolDownMin = 1.0f;
    public float coolDownMax = 3.0f;

    [Tooltip("Initial Cooldown Overwrite(when value is positive).")]
    public float startCooldown = -1;

    private Bullet bullet;
    private float cooldown;
    private long lastTime;

    [Header("Fire Warning")]
    public bool fireWarning = false;
    public float warningTime;
    private float prepareTime;
    private bool loaded = false;

    private void Start()
    {
        if (fireRoot == null)
            fireRoot = transform;
        ResetCoolDown(startCooldown);
    }

    private void Update()
    {
        if (fireWarning)
        {
            if (!loaded && DateTimeUtil.MillisecondsElapseFromMilliseconds(lastTime) > prepareTime)
            {
                LoadBullet();
            }
        }

        if (DateTimeUtil.MillisecondsElapseFromMilliseconds(lastTime) > cooldown)
        {
            Fire();
            ResetCoolDown();
        }
    }

    private void LoadBullet()
    {
        float angle = Random.Range(angleFrom, angleTo) + transform.eulerAngles.y - transform.eulerAngles.z;
        float speed = Random.Range(speedFrom, speedTo);
        Vector3 direction = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0);
        bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        bullet.transform.position = fireRoot.position;
        bullet.Init(direction * speed, Player.Instance?.transform);
        bullet.noDamage = true;
        bullet.enabled = false;

        loaded = true;
    }

    public void Fire()
    {
        if (!loaded)
            LoadBullet();

        if (bullet)
        {
            bullet.enabled = true;
            bullet.noDamage = false;
        }

        loaded = false;
    }

    private void ResetCoolDown(float cd = -1)
    {
        if (cd > 0)
            cooldown = cd * 1000;
        else
            cooldown = Random.Range(coolDownMin, coolDownMax) * 1000;
        if (fireWarning)
            prepareTime = cooldown - warningTime * 1000;

        lastTime = DateTimeUtil.GetUnixTimeMilliseconds();
    }

}
