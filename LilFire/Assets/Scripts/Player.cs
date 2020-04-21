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
        animator.PlayEat();
    }

    public void Die()
    {
        // Switch to GameLost state
        // UIManager show FinalScore element which is hidden, then wait for input
        Debug.Log("Game set to Lost from Player");
        MainGameManager.Instance.GameLost();
    }

    public void Respawn()
    {

    }
}
