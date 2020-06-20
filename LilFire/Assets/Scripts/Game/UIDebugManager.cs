using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugManager : SingletonBehaviour<UIDebugManager>
{
    public Text debugText1;
    public Text DebugText2;
    public Transform Arrow;

    private void Update()
    {
        //debugText1.text = Mathf.Cos(Player.Instance.playerMovement.playerCollision.collisions.leanAngle).ToString()
        //    + ", " + Mathf.Sin(Player.Instance.playerMovement.playerCollision.collisions.leanAngle).ToString();
        DebugText2.text = Player.Instance.playerMovement.GetVelocity().ToString();
    }
}
