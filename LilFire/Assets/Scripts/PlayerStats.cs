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
    private float decreasingSpeed = 2;
    public GameObject player;
    public BoardManager lvl;
    public float startingAltitude = 0;

    private PlayerCollision playercollision;
    private bool dying = false;

    private void OnEnable()
    {
        EventManager.OnPlayerLand += OnPlayerLand;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerLand -= OnPlayerLand;
    }


    // Start is called before the first frame update
    void Start()
    {
        playercollision = GetComponent<PlayerCollision>();
        player = Player.Instance.gameObject;
        lvl = BoardManager.Instance;

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
            if (energy <= 0) TryDie();
        }

    }

    public void UpdateEnergy(float value)
    {
        energy += value;
        if (energy <= 0)
        {
            energy = 0;
            TryDie();
        }
        energy = Mathf.Clamp(energy, 0, 120);
    }

    public void CollectItem()
    {

    }

    public void TryDie()
    {
        if (playercollision.collisions.below)
        {
            Die();
            return;
        }

        dying = true;
    }

    public void Die()
    {
        //Debug.Log("Player dies from running out of energy");
        lives--;
        UIManager.Instance.UpdateLife(lives);
        if (lives <= 0)
        {
            Player.Instance.Die();
        }
        else
        {
            Player.Instance.Respawn();
        }
        dying = false;
    }


   /*****************************************
    * 
    * Events
    * 
    *****************************************/
    private void OnPlayerLand()
    {
        if (dying)
            Die();
    }

}
