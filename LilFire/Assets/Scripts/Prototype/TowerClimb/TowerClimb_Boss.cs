using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClimb_Boss : SingletonBehaviour<TowerClimb_Boss>
{
    public Transform screenBottom;
    public Vector3 velocity = new Vector3(0, 10, 0);
    public Vector3 dampVel;

    [Header("BeamGun")]
    public BeamGun beamGun;

    private float dampTime = 1.0f;

    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
        if (transform.position.y < screenBottom.position.y)
        {
            transform.position = Vector3.SmoothDamp(transform.position,
                new Vector3(transform.position.x, screenBottom.position.y, transform.position.z), ref dampVel, dampTime);
            //transform.position = new Vector3(transform.position.x, screenBottom.position.y, transform.position.z);
        }
    }

    /*
    public Transform root;
    public Transform p1, p2;
    public float time;

    private float progress = 0;
    private Vector3 targetPosition;
    private void Awake()
    {
        if (root == null)
            root = transform;

        progress = 0;
        DOTween.To(() => progress, x => progress = x, 1, time).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        targetPosition = Vector3.Lerp(p1.position, p2.position, progress);
        root.transform.position = targetPosition;
    }
    */
}
