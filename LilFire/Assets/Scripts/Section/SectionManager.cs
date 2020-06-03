using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : SingletonBehaviour<SectionManager>
{
    public Transform root;
    public Transform heightDetector;
    public List<GameObject> sections;
    public Section currentSection;

    private int idx = -1;
    private Vector3 spawnPosition;

    private void OnEnable()
    {
        EventManager.OnSectionFinish += OnSectionFinish;
    }

    private void OnDisable()
    {
        EventManager.OnSectionFinish -= OnSectionFinish;
    }

    void Start()
	{
		if (currentSection != null)
			spawnPosition.y = currentSection.ceiling.position.y;
	}

    private void Update()
    {
        if (heightDetector.position.y > currentSection.ceiling.position.y)
        {
            SpawnNext();
        }
    }

    public void OnSectionFinish(Section section)
    {
        if (section != currentSection) return;

        SpawnNext();
    }

    public void SpawnNext()
    {
        int i = Random.Range(0, sections.Count);
        if (i == idx)
            i = (i + 1) % sections.Count;
        idx = i;

        GameObject sectionObj = Instantiate(sections[idx], spawnPosition, Quaternion.identity, root);
        currentSection = sectionObj.GetComponent<Section>();
        spawnPosition.y = currentSection.ceiling.position.y;
    }
}
