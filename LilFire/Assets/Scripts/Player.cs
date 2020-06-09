using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonBehaviour<Player>
{
    public LayerMask interactable;
    public CharacterSpineAnimator animator;

    private PlayerStats playerStats;
    private PlayerCollision playercollision;

    private void OnEnable()
    {
        EventManager.OnPlayerLand += OnPlayerLand;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerLand -= OnPlayerLand;
    }

    private void Start()
    {
        interactable = CollisionManager.Instance.Interactable;
        animator = GetComponent<CharacterSpineAnimator>();
        playerStats = PlayerStats.Instance;
        playercollision = GetComponent<PlayerCollision>();
    }

    public void Update()
    {
        /*
        //need non-trigger collider
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, interactable);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Fuel"))
            {
                hitInfo.collider.GetComponent<Fuel>().Collect();
            }

            if (hitInfo.collider.CompareTag("Cloud"))
            {
            }

            if (hitInfo.collider.CompareTag("Moth"))
            {
            }
        }
        */
    }

    public void CollectItem()
    {
        MusicManager.Instance?.PlayEat();
        animator.PlayEat();
    }

    public void Hurt()
    {
        MusicManager.Instance.PlayDamage();
        animator.PlayEat();
    }

    public void TryDie()
    {
        if (playercollision.collisions.below)
        {
            Die();
            return;
        }

        playerStats.dying = true;
    }

    public void Die()
    {
        playerStats.lives--;
        UIManager.Instance?.UpdateLife(PlayerStats.Instance.lives);
        if (PlayerStats.Instance.lives <= 0)
        {
            MainGameManager.Instance.GameLost();
            Destroy(gameObject);
        }
        else
        {
            Respawn();
        }
        playerStats.dying = false;
    }

    public void Respawn()
    {
        MusicManager.Instance?.PlayThunder();
        playerStats.energy = 100;
        PlayerMovement motionCtrl = GetComponent<PlayerMovement>();
        motionCtrl.Reset();

        Vector3 respawnPos = Vector3.zero;
        if (BoardManager.Instance != null)
        {
            BoardManager brd = BoardManager.Instance;
            GameObject checkPoint = brd.GetCurrentWaypoint();
            respawnPos = checkPoint.transform.position;
        }

        // put player a little higher than achieved waypoint or will fall through
        transform.position = respawnPos + 1.3f * Vector3.up;
        animator.PlayIdle();
    }

    public void CenterOnWaypoint()
    {
        // respawn at highest waypoint reached, showing corresponding number in log
        //Debug.Log("Respawning at waypoint " + PlayerStats.Instance.highestWaypoint);
        //PlayerMovement move = GameObject.FindObjectOfType<PlayerMovement>();
        // if currently aiming, release that
        //move.SetAiming(false);
        // go to the vector
        //move.GoToHighestWaypoint();
    }


    /*****************************************
     * 
     * Events
     * 
     *****************************************/
    private void OnPlayerLand()
    {
        if (playerStats.dying)
            Die();
    }
}
