using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSection : MonoBehaviour
{
    public GameObject cameraPos;

    public void EnterSection()
    {
        CameraTracker.Instance.ChangeCameraTarget(cameraPos, 4, 1.0f);
    }
}
