using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTrigger : MonoBehaviour
{
    private bool reached = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!reached && other.tag == "Player")
        {
            // Fire the method that extends the level upwards
            BoardManager lvl = GameObject.FindObjectOfType<LevelManager>().GetComponent<BoardManager>();
            lvl.WaypointReached();
            reached = true;
        }
    }
}
