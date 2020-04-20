using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonBehaviour<Player>
{
    public LayerMask interactable;

    private float distance = 2.5f;
    private CharacterSpineAnimator animator;

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

    }

    public void Respawn()
    {

    }
}
