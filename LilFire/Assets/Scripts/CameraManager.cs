using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonBehaviour<CameraManager>
{
    public Camera cam;

    public void PlayShake()
    {
        CameraShaker camShaker = cam.gameObject.AddComponent<CameraShaker>();
        camShaker.Play();
    }
}
