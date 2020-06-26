using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager_Contra : SingletonBehaviour<MainGameManager_Contra>
{
    private int sectionSpawned = 0;

    private void OnEnable()
    {
        EventManager.OnSectionSpawned += OnSectionSpawned;
    }

    private void OnDisable()
    {
        EventManager.OnSectionSpawned -= OnSectionSpawned;
    }

    private void Start()
    {
        SectionManager.Instance.SpawnBoss();
    }


    private void OnSectionSpawned (Section section)
    {
        sectionSpawned++;
        if (sectionSpawned == 3)
        {
            SectionManager.Instance.SpawnBoss();
            sectionSpawned = 0;
        }
    }
}
