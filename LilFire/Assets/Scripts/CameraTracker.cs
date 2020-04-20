using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    //private GameObject ourHero;

    // Start is called before the first frame update
    void Start()
    {
        //ourHero = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(point.x, 0.3f, point.z));
            // the following is for keeping the camera centered on target
            //Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }


        //Camera.Main.Transform.Translate(
        //this.gameObject.transform.position.y = ourHero.transform.position.y;
    }
}