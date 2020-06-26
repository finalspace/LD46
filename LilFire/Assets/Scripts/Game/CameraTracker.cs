using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : SingletonBehaviour<CameraTracker>
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    public bool neverFall = true;
    private float dampTimeCurrent;


    //private GameObject ourHero;

    // Start is called before the first frame update
    void Start()
    {
        //ourHero = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        dampTimeCurrent = dampTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(point.x, 0.5f, point.z));
            // the following is for keeping the camera centered on target
            //Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            //Vector3 destination = transform.position + delta;
            float h = Mathf.Max(target.position.y, transform.position.y);

            Vector3 destination = new Vector3(transform.position.x, h, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTimeCurrent);
        }


        //Camera.Main.Transform.Translate(
        //this.gameObject.transform.position.y = ourHero.transform.position.y;
    }

    public void ChangeCameraTarget(GameObject newTarget, float time, float dampingTime = -1)
    {
        target = newTarget.transform;
        if (dampingTime > 0)
            dampTimeCurrent = dampingTime;
        Invoke("TrackPlayer", time);
    }

    private void TrackPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        dampTimeCurrent = dampTime;
    }
}