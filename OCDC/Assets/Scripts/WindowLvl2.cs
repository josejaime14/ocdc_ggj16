using UnityEngine;
using System.Collections;

public class WindowLvl2 : MonoBehaviour
{

	public bool isCourtainClosed;

	private bool isWindowClosed;
	public Animator animCourtain, animWindow;
	private Vector3 startPoint, endPoint;
	private WindowHubLvl2 hub;

	// Use this for initialization
	void Start (){
		hub = transform.parent.GetComponent<WindowHubLvl2> ();
		//anim = GetComponent<Animator> ();
		isWindowClosed = false;
		animCourtain.SetBool ("closed", isCourtainClosed);
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
		float xDiference = Mathf.Abs (startPoint.x - endPoint.x);
		float yDiference = Mathf.Abs (startPoint.y - endPoint.y);

		if (distance > 1) {

			if (xDiference > yDiference) {//Horizontal drag
				if (isCourtainClosed)
					isCourtainClosed = false;
				else
					isCourtainClosed = true;
			} else if(!isCourtainClosed) {//Vertical drag
				if (startPoint.y < endPoint.y) {//Up
					isWindowClosed = false;
				} else if (startPoint.y > endPoint.y) {//Down
					isWindowClosed = true;
				}

			}
		}

		animWindow.SetBool ("closed",isWindowClosed);
		animCourtain.SetBool ("closed", isCourtainClosed);

		if (isCourtainClosed)
			hub.CheckValues ();
		//hub.UpdateValues (isWindowClosed&&isCourtainClosed);
	}

	public bool isValid(){
		return isWindowClosed && isCourtainClosed;
	}
}

