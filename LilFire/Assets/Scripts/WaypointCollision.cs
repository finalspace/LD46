using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class WaypointCollision : MonoBehaviour
{

    private float landedtime;
    private bool landed = false;
    private bool fireburning = false;
    private bool centered = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Energy steady while at camp!");
            // while player is here, energy doesn't run down
            // also, tentatively, we'll replenish it to 100%
            PlayerStats.Instance.losingEnergy = false;
            PlayerStats.Instance.energy = 100;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!landed && !fireburning)
            {
                landed = true;
                landedtime = Time.time;
            }
            else if (!fireburning && Time.time - landedtime >= 0.5f)
            {
                //Player.Instance.CenterOnWaypoint();
                MusicManager.Instance.PlayCampfire();
                fireburning = true;
                //centered = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Losing energy again! 2D");
            MusicManager.Instance.UndampenMusic();
            fireburning = false;
            landed = false;
            PlayerStats.Instance.losingEnergy = true;
        }
    }
}