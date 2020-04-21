using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class WaypointCollision : MonoBehaviour
{
    //void OnCollisionExit(Collision other)
    //{
    //    Debug.Log("Losing energy again!");
    //    if (other.gameObject.tag == "Player")
    //    {
    //        PlayerStats.Instance.losingEnergy = true;
    //    }
    //}
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Energy steady while at camp!");
        if (other.gameObject.tag == "Player")
        {
            // while player is here, energy doesn't run down
            // also, tentatively, we'll replenish it to 100%
            PlayerStats.Instance.losingEnergy = false;
            PlayerStats.Instance.energy = 100;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Losing energy again! 2D");
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.Instance.losingEnergy = true;
        }
    }
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