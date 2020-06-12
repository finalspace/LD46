using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeamGun : MonoBehaviour
{
    public GameObject core;
    public GameObject beam;
    public TextMeshPro countDownText;

    [Header("Behavior")]
    public LinearMovement movement;
    private Countdown countdown;

    private DateTime countDownStartTime;
    private bool showingCountDown = false;

    private void Start()
    {
        CoolDown();
    }

    private void Update()
    {
        if (!showingCountDown) return;

        countDownText.text = (3 - (DateTime.UtcNow - countDownStartTime).Seconds).ToString();
    }

    private void ShootCountDown()
    {
        core.SetActive(true);

        float time = 3;
        countdown = gameObject.AddComponent<Countdown>();
        countdown.StartCoundDown(time, PrepareShoot);
    }

    private void PrepareShoot()
    {
        countDownText.enabled = true;
        showingCountDown = true;
        movement.enabled = false;

        countDownStartTime = DateTime.UtcNow;
        float time = 3;
        countdown = gameObject.AddComponent<Countdown>();
        countdown.StartCoundDown(time, Shoot);
    }

    private void Shoot()
    {
        CameraManager.Instance.PlayShake();
        beam.SetActive(true);
        countDownText.enabled = false;
        movement.enabled = false;
        showingCountDown = false;

        float time = 3;
        countdown = gameObject.AddComponent<Countdown>();
        countdown.StartCoundDown(time, CoolDown);
    }

    private void CoolDown()
    {
        core.SetActive(false);
        beam.SetActive(false);
        countDownText.enabled = false;
        movement.enabled = true;

        float time = UnityEngine.Random.Range(5, 10);
        countdown = gameObject.AddComponent<Countdown>();
        countdown.StartCoundDown(time, ShootCountDown);
    }
}
