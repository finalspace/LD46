using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// Currently LevelManager calls SetupScene for initializing the first level
// blocks (sections), and WaypointReached is called by WaypointTrigger.
// The result is to generate the next block (section) of the level above
// the one most recently generated. This generally happens out of the player's
// sight, to make sure there's always more level waiting above.

// Eventually it would make sense to dynamically delete earlier blocks.

public class BoardManager : SingletonBehaviour<CollisionManager>
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
    public Count rocksCount = new Count(5, 20);
    // better to enter these as Counts also
    public Count xValues = new Count(-9, 9);
    public Count yValues = new Count(-3, 5);
    public GameObject waypoint;
    public GameObject campfire;
    public GameObject[] platformTiles;
    public GameObject[] fuelTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;
    public GameObject[] rockTiles;
    //public GameObject[] floorTiles;
    //private Transform wallsHolder;
    private List<Vector3> gridPositions = new List<Vector3>();
    private List<Vector3> pathVecs = new List<Vector3>();
    //private List<Vector3> pathGrowthPlateA = new List<Vector3>();
    //private List<Vector3> pathGrowthPlateB = new List<Vector3>();
    //private List<Vector3> pathGrowthPlateC = new List<Vector3>();
    //private List<GameObject> pathPlats = new List<GameObject>();
    public Vector3 bottomLeft, topRight;
    public Vector3 newBottomLeft, newTopRight;
    private Vector3 diff, gridX, gridY;
    private Vector3 pillarOffset = new Vector3(0f, -1f, 2f);
    public int blocksCreated = 0;

    // desired number of steps between waypoints
    //int stairs;
    // max radius of each step (guesstimate, needs to be <= actual value)
    float jumpDist = 5f;
    Vector3 jump;
    // track positions for generating platforms and waypoints
    Vector3 currPlatPos;
    Vector3 prevPlatPos;
    GameObject prevPlatObj;
    GameObject currPlatObj;
    Vector3 currWayPos;
    Vector3 nextWayPos;
    // highest waypoint character has reached
    Vector3 attainedWayPos;
    GameObject attainedWayObj;

    public Vector3 HighestWaypoint()
    {
        return attainedWayPos;
    }

    public void SetupScene(int level)
    {
        InitializeScreenGrid();
        // make campfire (first waypoint) and point all the references for generation here
        currWayPos = currPlatPos = prevPlatPos = attainedWayPos =
            Instantiate(campfire, new Vector3(0f, -3f, 0f), Quaternion.identity).transform.position;
        currPlatObj = prevPlatObj = currPlatObj = waypoint;
        // generate first block and waypoint after campfire, using initial bounds from xValues and yValues
        GenerateBlock();
        // generate second block and waypoint after campfire, which requires updating the bounds
        WaypointReached();
        // could generate even more blocks to start with, for testing
        //for (int i=0; i < 15; i++)
        //{
        //    WaypointReached();
        //}
    }

    private void InitializeScreenGrid()
    {
        //newBottomLeft = new Vector3(-9, -3f, 0f);
        //newTopRight = new Vector3(9f, 5f, 0f);
        newBottomLeft = new Vector3(xValues.minimum, yValues.minimum, 0f);
        newTopRight = new Vector3(xValues.maximum, yValues.maximum, 0f);
        diff = newTopRight - newBottomLeft;
        gridX = new Vector3(diff.x / columns, 0f, 0f);
        gridY = new Vector3(0f, diff.y / rows, 0f);
    }

    private void GenerateBlock()
    {
        blocksCreated++;
        ShowCorners();
        InitializeList();
        currWayPos = nextWayPos;
        nextWayPos = Instantiate(waypoint,
            new Vector3(Random.Range(newBottomLeft.x, newTopRight.x),
                newTopRight.y - Random.Range(-1, diff.x / 2), 0f),
            Quaternion.identity).transform.position;
        //prev

        LayoutPath();
        //LayoutPlatforms();
        //LayoutRockBark();
        LayoutFuel(fuelTiles, fuelCount.minimum, fuelCount.maximum);
        LayoutEnemies(enemyTiles, enemyCount.minimum, enemyCount.maximum);
    }

    public void WaypointReached()
    {
        NextScreenBlockBounds();
        GenerateBlock();
    }

    public void SetHighestWaypoint(GameObject g)
    {
        attainedWayObj = g;
        attainedWayPos = g.transform.position;
    }

    private void ShowCorners()
    {
        Instantiate(outerWallTiles[0], newBottomLeft, Quaternion.identity);
        Instantiate(outerWallTiles[0], new Vector3(newBottomLeft.x, newTopRight.y, 0f), Quaternion.identity);
        Instantiate(outerWallTiles[0], newTopRight, Quaternion.identity);
        Instantiate(outerWallTiles[0], new Vector3(newTopRight.x, newBottomLeft.y, 0f), Quaternion.identity);
    }

    //private void MakeBorders()
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

    private void InitializeList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns+1; x++)
        {
            for (int y = 1; y < rows+1; y++)
            {
                gridPositions.Add(newBottomLeft + x*gridX + y*gridY);
            }
        }
    }

    private void NextScreenBlockBounds()
    {
        newBottomLeft = new Vector3(newBottomLeft.x, newTopRight.y, 0f);
        newTopRight = newBottomLeft + diff;
    }

    private Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    //void LayoutObjectAtRandom(GameObject[] tileArray, string tag, int minimum, int maximum)
    //{
    //    int objectCount = Random.Range(minimum, maximum + 1);
    //    for(int i = 0; i < objectCount; i++)
    //    {
    //        Vector3 randomPosition = RandomPosition();
    //        GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
    //        Instantiate(tileChoice, randomPosition, Quaternion.identity).tag = tag;
    //    }
    //}

    private void LayoutPlatforms()
    {
        int objectCount = Random.Range(platformCount.minimum, platformCount.maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            MakePlatform(randomPosition);
        }
    }

    private GameObject MakePlatform(Vector3 here)
    {
        GameObject tileChoice = platformTiles[Random.Range(0, platformTiles.Length)];
        Quaternion twist = RandomRotation(20);
        //GameObject plat = Instantiate(tileChoice, here, twist);
        GameObject plat = Instantiate(tileChoice, here, Quaternion.identity);
        plat.tag = "Platform";
        // randomly twist and stretch by up to 1.5 or 1.75
        //plat.gameObject.transform.localScale = RandomScaleVector(1.7f);
        plat.gameObject.transform.localScale = RandomScaleVector(1f);
        //plat.gameObject.transform.localScale = new Vector3(Random.Range(1f, 1.7f), Random.Range(1f, 1.7f), 1);
        //plat.transform.eulerAngles = Vector3.forward * Random.Range(0, 20); // rotate 0 to 20 degrees

        // put a rock pillar beneath the platform
        //GameObject pillarChoice = rockTiles[Random.Range(0, rockTiles.Length)];
        //Instantiate(pillarChoice, here + pillarOffset, twist);

        return plat;
    }

    // I want a function that tells me how far I can jump, max, at every angle
    // range of a projectile - probably not far off of that function
    // seems to be proportional to sin(2*theta)
    // https://answers.unity.com/questions/973058/calculate-ai-jumping-the-gap.html

    private void LayoutPath()
    {
        Debug.Log("Lay out path");
        // displacement from this waypoint to next one
        Vector3 separation = nextWayPos - currWayPos;
        int loops = 0; // tracking softly so if we wander too long we can reign back in
        //for (int i = 0; i < 3; i++)
        while (separation.sqrMagnitude > jumpDist * jumpDist)
            {
            Debug.Log("Path loop" + loops);
            // scale unit vector randomly
            Debug.Log("Distance to next waypoint: "+separation);
            float randLength = Random.Range(1f, jumpDist);
            Debug.Log("random length: " + randLength);
            jump = separation.normalized * randLength;
            Debug.Log("jump vector: " + jump);

            // rotate randomly, including angles that move away
            // but not both x&y directions, so never turn 135 or more -
            // you don't want to use the quadrant that points
            // directly away and 45 degrees either way

            // this needs to be FIXED... conflating x and y distance somewhat, will produce artifacts
            if (separation.sqrMagnitude > Mathf.Pow(2.4f * jumpDist, 2f) || loops > 10)
            // if far away, point pretty much to waypoint
            {
                jump = RandomRotation(45f) * jump;
            } else if (separation.sqrMagnitude > Mathf.Pow(1.8f * jumpDist, 2f))
            // at medium distance, can go almost perpendicular
            {
                jump = RandomRotation(89f) * jump;
            } else
            // at small distance, can point away in one both not both dimensions
            {
                jump = RandomRotation(89f) * jump;
            }

            // make a new platform here, stash its position in the official pathway list
            prevPlatPos = currPlatPos;
            currPlatPos = currPlatPos + jump;

            if (currPlatPos.x <= xValues.minimum || currPlatPos.x >= xValues.maximum)
            {
                currPlatPos.x -= 2 * jump.x;
            }

            prevPlatObj = currPlatObj;
            pathVecs.Add(currPlatPos);
            currPlatObj = MakePlatform(currPlatPos);
            // stash this platform in the official pathway platform list
            //pathPlats.Add(newPlat);

            // don't forget THERE WAS A WEIRD BUG WITH ALIGNMENT... but the pathing should get around that
            // and the way to test it is to write code to generate many many blocks at once, don't try to
            // play test up to that altitude!

            // when randomly placing points, check for closeness to these and if close, don't place
            // could even handle that with a collider that deletes the random one after it's placed!

            // might want to write a function for bark also, done several places

            // run along path and put down bark, perhaps in another function, or here?

            // FUTURE
            // could simply verify that there's a path in the random stuff, patch over where not

            // waypoint - current position
            loops++;
            separation = nextWayPos - currPlatPos;
        }
    }

    void LayoutRockBark()
    {
        int objectCount = Random.Range(rocksCount.minimum, rocksCount.maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = rockTiles[Random.Range(0, rockTiles.Length)];
            Quaternion rot = RandomRotation(45f);
            GameObject plat = Instantiate(tileChoice, randomPosition, rot);
            // randomly twist and stretch by up to 1.5 or 1.75
            plat.gameObject.transform.localScale = RandomScaleVector(1.7f);

            //review this last part

            //plat.transform.eulerAngles = Vector3.forward * Random.Range(0, 20); // rotate 0 to 20 degrees
            // put a rock pillar beneath the pillar
            GameObject pillarChoice = this.rockTiles[Random.Range(0, this.rockTiles.Length)];
            Instantiate(pillarChoice, randomPosition + pillarOffset, rot);
        }
    }

    // this does not stretch a vector but generates a vector that represents 2D scaling
    Vector3 RandomScaleVector(float n)
    {
        // scale up to n times in x and y directions, separately
        return new Vector3(Random.Range(1f, n), Random.Range(1f, n), 1);
    }

    Quaternion RandomRotation(float n)
    {
        //rotate up to n degrees right or left, keeping flat
        return Quaternion.Euler(0f, 0f, Random.Range(-n, n));
    }

    // these two could be merged at least currently
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
        // decide how many fuels we'll have
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
