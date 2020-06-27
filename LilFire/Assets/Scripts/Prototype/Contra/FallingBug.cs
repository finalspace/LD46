using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBug : MonoBehaviour
{
    public SimpleMovement movement;

    public void Start()
    {
        movement.landEvent.AddListener(OnLand);
    }

    public void OnLand(Collider2D groundCollider)
    {
        Vector3 diff = Player.Instance.transform.position - transform.position;
        movement.Move(Vector2.zero, Mathf.Sign(diff.x) * 2);
    }
}
