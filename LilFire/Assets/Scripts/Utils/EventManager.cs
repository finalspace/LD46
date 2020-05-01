using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void PlayerLand();
    public static event PlayerLand OnPlayerLand;

    public delegate void PlayerJump(float power);
    public static event PlayerJump OnPlayerJump;

    public delegate void PlayerJumpFailed();
    public static event PlayerJumpFailed OnPlayerJumpFailed;

    public static void Event_PlayerLand()
    {
        OnPlayerLand();
    }

    public static void Event_PlayerJump(float power)
    {
        OnPlayerJump(power);
    }

    public static void Event_PlayerJumpFail()
    {
        OnPlayerJumpFailed();
    }




}
