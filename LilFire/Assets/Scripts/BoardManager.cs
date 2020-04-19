﻿using System;
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
    public int columns;
    public int rows;
    public Count platformCount = new Count(5, 9);
    public Count fuelCount = new Count(1, 5);
    public Count enemyCount = new Count(5, 9);
    public GameObject waypoint;
    public GameObject campfire;
    //public GameObject[] floorTiles;
    public GameObject[] platformTiles;
    public GameObject[] fuelTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;
    private Transform wallsHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    private Vector3 bottomLeft, topRight, diff, gridX, gridY;

    void InitializeList()
    {
        gridPositions.Clear();

        bottomLeft = new Vector3(-9f, -3f, 0f);
        topRight = new Vector3(9f, 5f, 0f);
        diff = topRight - bottomLeft;
        gridX = new Vector3(diff.x / columns, 0f, 0f);
        gridY = new Vector3(0f, diff.y / rows, 0f);

        for (int x = 1; x < columns+1; x++)
        {
            for (int y = 1; y < rows+1; y++)
            {
                gridPositions.Add(bottomLeft + x*gridX + y*gridY);
            }
        }
    }

    void WallsSetup()
    {
        Instantiate(outerWallTiles[0], new Vector3(-9f, -3f, 0f), Quaternion.identity);
        Instantiate(outerWallTiles[0], new Vector3(-9f, 5f, 0f), Quaternion.identity);
        Instantiate(outerWallTiles[0], new Vector3(9f, 5f, 0f), Quaternion.identity);
        Instantiate(outerWallTiles[0], new Vector3(9f, -3f, 0f), Quaternion.identity);

        //wallsHolder = new GameObject("Walls").transform;

        //for (int x = -1; x < columns + 1; x++)
        //{
        //    for (int y = -1; y < rows + 1; y++)
        //    {
        //        GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
        //        if (x == -1 || x == -1 || x == columns || y == rows)
        //        {
        //            toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
        //        }
        //        GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        //        instance.transform.SetParent(wallsHolder);
        //    }
        //}
    }

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
            Instantiate(tileChoice, randomPosition, Quaternion.identity).tag = tag;
        }
    }

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
            randomPosition.y += 1f;
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    void LayoutFuel(GameObject[] tileArray, int minimum, int maximum)
    {
        // decide how many enemies we'll have
        int objectCount = Random.Range(minimum, maximum + 1);
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        for (int i = 0; i < objectCount; i++)
        {
            // pick a random fuel type
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            // pick a random platform to put the fuel on
            GameObject randomPlatform = platforms[Random.Range(0, platforms.Length)];
            Vector3 randomPosition = randomPlatform.transform.position;
            // shift up so it's standing on platform (or use half of fuel's height)
            randomPosition.y += 1f;
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        WallsSetup();
        InitializeList();
        LayoutObjectAtRandom(platformTiles, "Platform", platformCount.minimum, platformCount.maximum);
        LayoutFuel(fuelTiles, fuelCount.minimum, fuelCount.maximum);
        LayoutEnemies(enemyTiles, enemyCount.minimum, enemyCount.maximum);
        Instantiate(campfire, new Vector3(0f, -3f, 0f), Quaternion.identity);
        Instantiate(waypoint, new Vector3(Random.Range(bottomLeft.x, topRight.x), rows - 1, 0f), Quaternion.identity);
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
