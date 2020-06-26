using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void PlayerLand();
    public static event PlayerLand OnPlayerLand;

    public delegate void PlayerJump(Vector3 vel);
    public static event PlayerJump OnPlayerJump;

    public delegate void PlayerJumpFailed();
    public static event PlayerJumpFailed OnPlayerJumpFailed;

    public delegate void Aiming();
    public static event Aiming OnAiming;

    public delegate void ReleaseAiming();
    public static event ReleaseAiming OnReleaseAiming;

    public delegate void SectionFinish(Section section);
    public static event SectionFinish OnSectionFinish;

    public delegate void SectionSpawned(Section section);
    public static event SectionSpawned OnSectionSpawned;

    public delegate void BossSectionFinished(Section section);
    public static event BossSectionFinished OnBossSectionFinished;

    public static void Event_PlayerLand()
    {
        OnPlayerLand();
    }

    public static void Event_PlayerJump(Vector3 vel)
    {
        OnPlayerJump(vel);
    }

    public static void Event_PlayerJumpFail()
    {
        OnPlayerJumpFailed();
    }

    public static void Event_PlayerAiming()
    {
        OnAiming();
    }

    public static void Event_PlayerStopAiming()
    {
        OnReleaseAiming();
    }

    public static void Event_SectionFinish(Section section)
    {
        OnSectionFinish(section);
    }

    public static void Event_SectionSpawned(Section section)
    {
        if (OnSectionSpawned != null)
            OnSectionSpawned(section);
    }

    public static void Event_BossSectionFinish(Section section)
    {
        OnBossSectionFinished(section);
    }


}
