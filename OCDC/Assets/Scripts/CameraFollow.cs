using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;

	public float verticalOffset;
	public float lookAheadDstX;
	public float lookSmoothTimeX;
	public float verticalSmoothTime;
	public Vector2 focusAreaSize;

	FocusArea focusArea;

	float currentLookAheadX;
	float targetLookAheadX;
	float lookAheadDirX;
	float smoothLookVelocityX;
	float smoothVelocityY;

	bool lookAheadStopped;

	// Use this for initialization
	void Start () {
		focusArea = new FocusArea (BoundsColliders(player), focusAreaSize);
	}
	
	void LateUpdate() {
		focusArea.Update (BoundsColliders(player));

		Vector2 focusPosition = focusArea.centre + Vector2.up * verticalOffset;




		currentLookAheadX = Mathf.SmoothDamp (currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);

		focusPosition.y = Mathf.SmoothDamp (transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
		focusPosition += Vector2.right * currentLookAheadX;
		transform.position = (Vector3)focusPosition + Vector3.forward * -10;
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (1, 0, 0, .2f);
		Gizmos.DrawCube (focusArea.centre, focusAreaSize);
	}

	public static Bounds BoundsColliders(GameObject obj) {
		var bounds = new Bounds(obj.transform.position, Vector3.zero);

		var colliders = obj.GetComponentsInChildren<Collider2D>();
		foreach(var c in colliders) {
			var blocal =BoundsOf(c);
			var t = c.transform;
			var max = t.TransformPoint(blocal.max);
			bounds.Encapsulate(max);
			var min = t.TransformPoint(blocal.min);
			bounds.Encapsulate(min);
		}

		return bounds;
	}

	public static Bounds BoundsOf(Collider2D collider) {
		var bounds = new Bounds ();

		var bc = collider as BoxCollider2D;
		if (bc) {
			var ext = bc.size * 0.5f;
			bounds.Encapsulate (new Vector3 (-ext.x, -ext.y, 0f));
			bounds.Encapsulate (new Vector3 (ext.x, ext.y, 0f));
			return bounds;
		}

		var cc = collider as CircleCollider2D;
		if (cc) {
			var r = cc.radius;
			bounds.Encapsulate (new Vector3 (-r, -r, 0f));
			bounds.Encapsulate (new Vector3 (r, r, 0f));
			return bounds;
		}

		Debug.LogWarning("Unknown type "+bounds);

		return bounds;
	}

	struct FocusArea {
		public Vector2 centre;
		public Vector2 velocity;
		float left,right;
		float top,bottom;


		public FocusArea(Bounds targetBounds, Vector2 size) {
			left = targetBounds.center.x - size.x/2;
			right = targetBounds.center.x + size.x/2;
			bottom = targetBounds.min.y;
			top = targetBounds.min.y + size.y;

			velocity = Vector2.zero;
			centre = new Vector2((left+right)/2,(top +bottom)/2);
		}

		public void Update(Bounds targetBounds) {
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bottom) {
				shiftY = targetBounds.min.y - bottom;
			} else if (targetBounds.max.y > top) {
				shiftY = targetBounds.max.y - top;
			}
			top += shiftY;
			bottom += shiftY;
			centre = new Vector2((left+right)/2,(top +bottom)/2);
			velocity = new Vector2 (shiftX, shiftY);
		}
	}
}
