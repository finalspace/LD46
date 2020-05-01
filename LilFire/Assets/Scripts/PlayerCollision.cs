using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider2D))]
public class PlayerCollision : MonoBehaviour {
	const float skinWidth = .015f;
	public int horizontalRayCount = 4;
	public int verticalRayCount = 4;

    private LayerMask oneSideCollision;
    private LayerMask hardCollision;

    float horizontalRaySpacing;
	float verticalRaySpacing;

	BoxCollider2D collider;
	RaycastOrigins raycastOrigins;
	public CollisionInfo collisions;


	void Start() {
		collider = GetComponent<BoxCollider2D> ();
		CalculateRaySpacing ();
        oneSideCollision = CollisionManager.Instance.OneSideGound;
        hardCollision = CollisionManager.Instance.HardBlock;
    }

	public void Move(Vector3 velocity) {
		
		UpdateRaycastOrigins ();
		collisions.Reset ();

		if (velocity.x != 0) {
			HorizontalCollisions (ref velocity);
		}
		if (velocity.y != 0) {
			VerticalCollisions (ref velocity);
		}

		transform.Translate (velocity);
	}

    public void MoveIgnoreCollision(Vector3 velocity)
    {
        transform.Translate(velocity);
    }

	void HorizontalCollisions(ref Vector3 velocity) {
		float directionX = Mathf.Sign (velocity.x);
		float rayLength = Mathf.Abs (velocity.x) + skinWidth;
        bool left = (directionX == -1);

        LayerMask collisionMask = hardCollision;
        for (int i = 0; i < horizontalRayCount; i ++) {
			Vector2 rayOrigin = left ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength,Color.red);

			if (hit) {
				velocity.x = (hit.distance - skinWidth) * directionX;
				rayLength = hit.distance;

				collisions.left = left;
				collisions.right = !left;

                if (left)
                    collisions.leftTransform = hit.transform;
                else collisions.rightTransform = hit.transform;
            }
		}
	}

	void VerticalCollisions(ref Vector3 velocity) {
		float directionY = Mathf.Sign (velocity.y);
		float rayLength = Mathf.Abs (velocity.y) + skinWidth;
        bool below = (directionY == -1);

        LayerMask collisionMask = directionY > 0 ? hardCollision : oneSideCollision;
		for (int i = 0; i < verticalRayCount; i ++) {
			Vector2 rayOrigin = below ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength,Color.red);

			if (hit) {
				velocity.y = (hit.distance - skinWidth) * directionY;
				rayLength = hit.distance;

                collisions.below = below;
				collisions.above = !below;

                if (below)
                    collisions.belowTransform = hit.transform;
                else collisions.aboveTransform = hit.transform;

            }
		}
	}

	void UpdateRaycastOrigins() {
		Bounds bounds = collider.bounds;
		bounds.Expand (skinWidth * -2);

		raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2 (bounds.max.x, bounds.max.y);
	}

	void CalculateRaySpacing() {
		Bounds bounds = collider.bounds;
		bounds.Expand (skinWidth * -2);

		horizontalRayCount = Mathf.Clamp (horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp (verticalRayCount, 2, int.MaxValue);

		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	}

	struct RaycastOrigins {
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}

	public struct CollisionInfo {
		public bool above, below;
		public bool left, right;

        public Transform aboveTransform, belowTransform, leftTransform, rightTransform;

		public void Reset() {
			above = below = false;
			left = right = false;
            aboveTransform = belowTransform = leftTransform = rightTransform = null;

        }
	}

}


