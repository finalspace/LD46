using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTrigger : MonoBehaviour
{
    private bool reached = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Waypoint!");
        if (!reached && other.tag == "Player")
        {
            // Fire the method that extends the level upwards
            BoardManager lvl = GameObject.FindObjectOfType<LevelManager>().GetComponent<BoardManager>();
            lvl.SetHighestWaypoint(gameObject);
            lvl.WaypointReached();
            Debug.Log("New waypoint unlocked!");
            reached = true;
        }
    }


    //void OnCollisionExit(Collision other)
    //{
    //    Debug.Log("Losing energy again!");
    //    if (other.gameObject.tag == "Player")
    //    {
    //        PlayerStats.Instance.losingEnergy = true;
    //    }
    //}
    //void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log("Energy steady while at camp!");
    //    if (other.gameObject.tag == "Player")
    //    {
    //        // while player is here, energy doesn't run down
    //        // also, tentatively, we'll replenish it to 100%
    //        PlayerStats.Instance.losingEnergy = false;
    //        PlayerStats.Instance.energy = 100;
    //    }
    //}

    //void OnCollisionExit2D(Collision2D other)
    //{
    //    Debug.Log("Losing energy again! 2D");
    //    if (other.gameObject.tag == "Player")
    //    {
    //        PlayerStats.Instance.losingEnergy = true;
    //    }
    //}
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("Energy steady while at camp! 2D");
    //    if (other.gameObject.tag == "Player")
    //    {
    //        // while player is here, energy doesn't run down
    //        // also, tentatively, we'll replenish it to 100%
    //        PlayerStats.Instance.losingEnergy = false;
    //        PlayerStats.Instance.energy = 100;
    //    }
    //}
}
