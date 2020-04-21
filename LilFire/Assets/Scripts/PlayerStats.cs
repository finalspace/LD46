using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : SingletonBehaviour<PlayerStats>
{
    public float maxHeight = 0;
    public int lives = 3;
    public int score = 0;
    public int highestWaypoint = 0;
    public bool losingEnergy = true;
    public float fatalHeightFalling = -14;
    public float energy = 100;
    private float decreasingSpeed = 5;
    public GameObject player;
    public BoardManager lvl;
    public float startingAltitude = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance.gameObject;
        lvl = GameObject.FindObjectOfType<LevelManager>().GetComponent<BoardManager>();

        startingAltitude = player.transform.position.y;
        maxHeight = player.transform.position.y - startingAltitude;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > maxHeight)
        {
            maxHeight = player.transform.position.y - startingAltitude;
            score = Mathf.FloorToInt(maxHeight);
            highestWaypoint = lvl.blocksCreated - 1;
        }
        if (energy > 0 && losingEnergy)
        {
            energy -= Time.deltaTime * decreasingSpeed;

            if (energy <= 0)
                Die();
        }

    }

    public void UpdateEnergy(float value)
    {
        energy += value;
        energy = Mathf.Clamp(energy, 0, 100);
    }



    public void CollectItem()
    {

    }

    public void Die()
    {
        Player.Instance.Die();
    }

    public void Respawn()
    {

    }


}
