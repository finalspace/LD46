using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void PlayerLand();
    public static event PlayerLand OnPlayerLand;


    public static void Event_PlayerLand()
    {
        OnPlayerLand();
    }
}
