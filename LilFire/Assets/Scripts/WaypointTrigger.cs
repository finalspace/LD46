﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTrigger : MonoBehaviour
{
    private bool reached = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("WAYPOINT REACHED");
        //Debug.Log("REACHED BEFORE?" + reached);
        //Debug.Log("OTHER TAG:" + other.tag);
        if (!reached && other.tag == "Player")
        {
            Debug.Log("AND TRIGGERED");
            // Fire the method that extends the level upwards
            BoardManager lvl = GameObject.FindObjectOfType<LevelManager>().GetComponent<BoardManager>();
            lvl.WaypointReached();
            reached = true;
        }
    }
}
