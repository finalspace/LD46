using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonBehaviour<Player>
{
    public LayerMask interactable;
    public CharacterSpineAnimator animator;

    private float distance = 1.0f;

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
        if (PlayerStats.Instance.lives <= 0)
        {
            // Switch to GameLost state
            // UIManager show FinalScore element which is hidden, then wait for input
            Debug.Log("Game over, set to Lost from Player.cs");
            MainGameManager.Instance.GameLost();
        }
        else
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        MusicManager.Instance.PlayThunder();
        // respawn at highest waypoint reached, showing corresponding number in log
        Debug.Log("Respawning at waypoint " + PlayerStats.Instance.highestWaypoint);
        PlayerMovement move = GameObject.FindObjectOfType<PlayerMovement>();
        // go to the vector
        move.GoToHighestWaypoint();
    }

    public void CenterOnWaypoint()
    {
        // respawn at highest waypoint reached, showing corresponding number in log
        Debug.Log("Respawning at waypoint " + PlayerStats.Instance.highestWaypoint);
        PlayerMovement move = GameObject.FindObjectOfType<PlayerMovement>();
        // go to the vector
        move.GoToHighestWaypoint();
    }
}
