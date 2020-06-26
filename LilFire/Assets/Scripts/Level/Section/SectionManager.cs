using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : SingletonBehaviour<SectionManager>
{
    public Transform root;
    public Transform heightDetector;
    public List<GameObject> sections;
    public Section currentSection;

    [Header("Boss")]
    public List<GameObject> bossSections;

    private int idx = -1;
    public Vector3 spawnPosition;
    private bool spawning = true;

    private void OnEnable()
    {
        EventManager.OnSectionFinish += OnSectionFinish;
    }

    private void OnDisable()
    {
        EventManager.OnSectionFinish -= OnSectionFinish;
    }

    void Awake()
	{
		if (currentSection != null)
			spawnPosition.y = currentSection.ceiling.position.y;
	}

    private void Update()
    {
        if (!spawning) return;

        if (heightDetector.position.y > currentSection.ceiling.position.y)
        {
            SpawnNext();
        }
    }

    public void OnSectionFinish(Section section)
    {
        if (section != currentSection) return;

        //SpawnNext();
    }

    public void OnBossSectionFinish(Section section)
    {
        StartSpawn();
    }

    public void SpawnNext()
    {
        SpawnRegular();
    }

    private void SpawnRegular()
    {
        int i = Random.Range(0, sections.Count);
        if (i == idx)
            i = (i + 1) % sections.Count;
        idx = i;

        GameObject sectionObj = Instantiate(sections[idx], spawnPosition, Quaternion.identity, root);
        currentSection = sectionObj.GetComponent<Section>();
        spawnPosition.y = currentSection.ceiling.position.y;

        EventManager.Event_SectionSpawned(currentSection);
    }

    public void SpawnBoss()
    {
        int i = Random.Range(0, bossSections.Count);
        if (i == idx)
            i = (i + 1) % bossSections.Count;
        idx = i;

        GameObject sectionObj = Instantiate(bossSections[idx], spawnPosition, Quaternion.identity, root);
        currentSection = sectionObj.GetComponent<Section>();
        spawnPosition.y = currentSection.ceiling.position.y;

        EventManager.Event_SectionSpawned(currentSection);
        PauseSpawn();
    }

    public void PauseSpawn()
    {
        spawning = false;
    }

    public void StartSpawn()
    {
        spawning = true;
    }
}
