using UnityEngine;
using System.Collections;

public class Vessel : MonoBehaviour {

	public int position, value;

	private Vector3 startPoint, endPoint;
	private VesselHub hub;
	private Vector3 leftPos, midlePos, rightPos;
	// Use this for initialization
	void Start (){
		hub = transform.parent.GetComponent<VesselHub> ();
		switch (position) {
		case 1:
			leftPos = transform.position;
			midlePos = new Vector3 (leftPos.x + 1.5f, transform.position.y, transform.position.z);
			rightPos = new Vector3 (midlePos.x + 1.5f, transform.position.y, transform.position.z);
			break;
		case 2:
			midlePos = transform.position;
			leftPos = new Vector3 (midlePos.x - 1.5f, transform.position.y, transform.position.z);
			rightPos = new Vector3 (midlePos.x + 1.5f, transform.position.y, transform.position.z);
			break;
		case 3:
			rightPos = transform.position;
			midlePos = new Vector3 (rightPos.x - 1.5f, transform.position.y, transform.position.z);
			leftPos = new Vector3 (midlePos.x - 1.5f, transform.position.y, transform.position.z);
			break;
		}
	}

	void Update(){
		switch (position) {
		case 1:
			transform.position = Vector3.Lerp (transform.position, leftPos, 0.1f);
			break;
		case 2:
			transform.position = Vector3.Lerp (transform.position, midlePos, 0.1f);
			break;
		case 3:
			transform.position = Vector3.Lerp (transform.position, rightPos, 0.1f);
			break;
		}
	}
	void OnMouseDown() {
		startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void OnMouseUp(){
		endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Shift ();
	}

	private void Shift(){
		float distance = Vector3.Distance (startPoint, endPoint);

		if (distance > 1) {
			if (startPoint.x < endPoint.x && position < 3) {//Right
				hub.Shift (position, position + 1);
			} else if (startPoint.x > endPoint.x && position > 1) {//Left 
				hub.Shift (position, position - 1);
			}
		} else {
			Debug.Log ("not enough");
		}
	}
}
