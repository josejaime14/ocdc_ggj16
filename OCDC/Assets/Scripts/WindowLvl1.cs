using UnityEngine;
using System.Collections;

public class WindowLvl1 : MonoBehaviour {

	public bool isClosed;

	private Animator anim;
	private Vector3 startPoint, endPoint;
	private WindowHubLvl1 hub;

	// Use this for initialization
	void Start (){
		hub = transform.parent.GetComponent<WindowHubLvl1> ();
		anim = GetComponent<Animator> ();
		anim.SetBool ("state", isClosed);
	}

	void OnMouseDown() {
		//Debug.Log ("clicked");
		startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void OnMouseUp(){
		endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		ChangeState ();
	}

	private void ChangeState(){
		float distance = Vector3.Distance (startPoint, endPoint);

		if (distance > 1) {
			if (startPoint.y < endPoint.y) {//Up
				isClosed = false;
			} else if (startPoint.y > endPoint.y) {//Down
				isClosed = true;
			}
		}
		anim.SetBool ("state", isClosed);
		hub.UpdateValues (isClosed);
	}
}
