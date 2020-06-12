using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonBehaviour<Player>
{
    public CharacterSpineAnimator animator;

    private PlayerMovement playerMovement;
    private PlayerStats playerStats;
    private PlayerCollision playercollision;

    private bool isSimulating = true;

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
        playerStats = PlayerStats.Instance;
        animator = GetComponent<CharacterSpineAnimator>();
        playerMovement = GetComponent<PlayerMovement>();
        playercollision = GetComponent<PlayerCollision>();
    }

    public void Update()
    {
        // die if player height goes below the starting level; can update the fatal height as we got
        if (transform.position.y < playerStats.fatalHeightFalling)
        {
            Kill();
        }
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



    /*****************************************
     * 
     * Actions
     * 
     *****************************************/

    /// <summary>
    /// character doesn't react to game systems
    /// </summary>
    public void StopSimulation()
    {
        isSimulating = false;
        playerMovement.StopSimulation();
    }

    public void StartSimulation()
    {
        isSimulating = true;
        playerMovement.StartSimulation();
    }

    public void CollectItem()
    {
        MusicManager.Instance?.PlayEat();
        animator.PlayEat();
    }

    /// <summary>
    /// Damage()->Kill()->Die()
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage = 0)
    {
        if (!isSimulating || playerStats.IsInvulnerable) return;

        MusicManager.Instance?.PlayDamage();
        animator.PlayHurt();

        //todo: damage system to trigger Kill/Die
        Die();
    }

    public void Kill()
    {
        if (!isSimulating || playerStats.IsInvulnerable) return;

        Die();
    }

    /// <summary>
    /// set to dying status. allow some last chances to survive
    /// i.e. character running out of energy in the air, but will survive if he lands on a fuel or campfire
    /// </summary>
    public void SoftKill()
    {
        if (playercollision.collisions.below)
        {
            Die();
            return;
        }

        playerStats.isDying = true;
    }

    private void Die()
    {
        playerStats.lives--;
        UIManager.Instance?.UpdateLife(playerStats.lives);
        if (playerStats.lives <= 0)
        {
            MainGameManager.Instance.GameLost();
            Destroy(gameObject);
        }
        else
        {
            Invoke("Respawn", 2);
        }

        playerStats.isDying = false;
        animator.PlayDie();

        StopSimulation();
    }

    public void Respawn()
    {
        MusicManager.Instance?.PlayThunder();
        playerStats.energy = 100;
        playerMovement.Reset();
        transform.position = GetRespawnPosition();
        animator.PlayBirth();
        SetInvulnerable();
        Invoke("DismissInvulnerable", 3);

        StartSimulation();
    }

    private Vector3 GetRespawnPosition()
    {
        Vector3 respawnPos = Vector3.zero;
        if (BoardManager.Instance != null)
        {
            BoardManager brd = BoardManager.Instance;
            GameObject checkPoint = brd.GetCurrentWaypoint();
            respawnPos = checkPoint.transform.position;
        }
        else
        {
            respawnPos = CameraManager.Instance.transform.position + 2f * Vector3.up;
            respawnPos.z = 0;
        }

        // put player a little higher than achieved waypoint or will fall through
        respawnPos += 1.3f * Vector3.up;

        
        return respawnPos;
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
     * Status
     * 
     *****************************************/

    public void SetInvulnerable()
    {
        animator.PlayFlash();
        playerStats.IsInvulnerable = true;
        Invoke("DismissInvulnerable", 3);
    }

    public void DismissInvulnerable()
    {
        animator.StopFlash();
        playerStats.IsInvulnerable = false;
    }



    /*****************************************
     * 
     * Events
     * 
     *****************************************/
    private void OnPlayerLand()
    {
        if (playerStats.isDying)
            Kill();
    }
}
