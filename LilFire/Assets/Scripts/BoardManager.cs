using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int maximum;
        public int minimum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    public int columns = 8;
    public int rows = 8;
    public Count platformCount = new Count(5, 9);
    public Count fuelCount = new Count(1, 5);
    public Count enemyCount = new Count(5, 9);
    public GameObject waypoint;
    public GameObject campfire;
    //public GameObject[] floorTiles;
    public GameObject[] platformTiles;
    public GameObject[] fuelTiles;
    public GameObject[] enemyTiles;
    //public GameObject[] outerWallTiles;
    private Transform wallsHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x,y,0f));
            }
        }
    }

    //void WallsSetup()
    //{
    //    wallsHolder = new GameObject("Walls").transform;

    //    for (int x = -1; x < columns + 1; x++)
    //    {
    //        for (int y = -1; y < rows + 1; y++)
    //        {
    //            GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
    //            if (x == -1 || x == -1 || x == columns || y == rows)
    //            {
    //                toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
    //            }
    //            GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
    //            instance.transform.SetParent(wallsHolder);
    //        }
    //    }
    //}

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, string tag, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            //tileChoice.tag = tag;
            Instantiate(tileChoice, randomPosition, Quaternion.identity).tag = tag;
        }
    }

    //void LayoutPlatforms(GameObject[] tileArray, int minimum, int maximum)
    //{
    //    int objectCount = Random.Range(minimum, maximum + 1);
    //    for (int i = 0; i < objectCount; i++)
    //    {
    //        Vector3 randomPosition = RandomPosition();
    //        GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
    //        tileChoice.tag = "platform";
    //        Instantiate(tileChoice, randomPosition, Quaternion.identity);
    //    }
    //}

    void LayoutEnemies(GameObject[] tileArray, int minimum, int maximum)
    {
        // decide how many enemies we'll have
        int objectCount = Random.Range(minimum, maximum + 1);
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        for (int i = 0; i < objectCount; i++)
        {
            // pick a random enemy type
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            // pick a random platform to put the enemy on
            GameObject randomPlatform = platforms[Random.Range(0, platforms.Length)];
            Vector3 randomPosition = randomPlatform.transform.position;
            // shift up so it's standing on platform (or use half of enemy's height)
            randomPosition.y += 0.8f;
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        //WallsSetup();
        InitializeList();
        LayoutObjectAtRandom(platformTiles, "Platform", platformCount.minimum, platformCount.maximum);
        //LayoutObjectAtRandom(fuelTiles, "Fuel", fuelCount.minimum, fuelCount.maximum);
        LayoutEnemies(enemyTiles, enemyCount.minimum, enemyCount.maximum);
        Instantiate(campfire, new Vector3(0f, -3f, 0f), Quaternion.identity);
        Instantiate(waypoint, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
