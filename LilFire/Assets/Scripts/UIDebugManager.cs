using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugManager : MonoBehaviour
{
    public Text debugText1;
    public Text DebugText2;

    private void Update()
    {
        debugText1.text = Player.Instance.playerMovement.playerCollision.collisions.below.ToString();
        DebugText2.text = Player.Instance.playerMovement.GetVelocity().ToString();
    }
}
