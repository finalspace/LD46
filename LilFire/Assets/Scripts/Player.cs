using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonBehaviour<Player>
{
    public LayerMask interactable;
    public CharacterSpineAnimator animator;

    //private float distance = 1.0f;

    private void Start()
    {
        interactable = CollisionManager.Instance.Interactable;
        animator = GetComponent<CharacterSpineAnimator>();
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
        MusicManager.Instance.PlayEat();
        animator.PlayEat();
    }

    public void Hurt()
    {
        MusicManager.Instance.PlayDamage();
        animator.PlayEat();
    }

    public void Die()
    {
        PlayerStats.Instance.lives--;
        UIManager.Instance.UpdateLife(PlayerStats.Instance.lives);
        if (PlayerStats.Instance.lives <= 0)
        {
            MainGameManager.Instance.GameLost();
            Destroy(gameObject);
        }
        else
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        MusicManager.Instance.PlayThunder();
        // refill energy in case player doesn't connect with waypoint properly
        PlayerStats.Instance.energy = 100;
        // respawn at highest waypoint reached, showing corresponding number in log
        //Debug.Log("Respawning at waypoint " + PlayerStats.Instance.highestWaypoint);
        PlayerMovement move = GetComponent<PlayerMovement>();

        move.Reset();

        BoardManager brd = BoardManager.Instance;
        GameObject respawnPoint = brd.GetCurrentWaypoint();

        // put player a little higher than achieved waypoint or will fall through
        transform.position = respawnPoint.transform.position + 1.3f * Vector3.up;
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
}
