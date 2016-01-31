using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Obstacle))]
public class PictureFrameLvl2 : MonoBehaviour
{
	public int dragTypeX = 1;
	public int dragTypeY = 1;
	public Transform resultTransform;


	private Animator anim;
	private Obstacle obstacle;
	private Vector3 startPoint, endPoint;
	private MainGameController mainController;


	// Use this for initialization
	void Start (){
		anim = GetComponent<Animator> ();
		obstacle = GetComponent<Obstacle> ();
		mainController =(MainGameController)GameObject.FindObjectOfType (typeof(MainGameController));
	}

	void Update(){
		if(obstacle.isSolved())
			transform.position = Vector3.Lerp (transform.position, resultTransform.position, 0.1f);
	}
	void OnMouseDown() {
		//Debug.Log ("clicked");
		startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	/*
	void OnMouseDrag()
	{
		endPoint  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		endPoint.z = gameObject.transform.position.z;
		float distance = Vector3.Distance(originalPosition,endPoint);
		if(distance < 1)
			transform.position = endPoint;
	}
	*/

	void OnMouseUp(){
		endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Validate () && !obstacle.isSolved()) {
			anim.SetBool ("solved", true);
			obstacle.solved ();
			mainController.addObstacleSolved ();
		}
	}

	private bool Validate(){
		bool isValid = false;
		float distance = Vector3.Distance (startPoint, endPoint);

		if (distance > 1) {
			if (startPoint.x < endPoint.x && dragTypeX > 0) {//Right
				isValid = true;
			} else if (startPoint.x > endPoint.x && dragTypeX < 0) {//Left 
				isValid = true;
			}

			if (startPoint.y < endPoint.y && dragTypeY > 0) {//Up
				isValid = true;
			} else if (startPoint.y > endPoint.y && dragTypeY < 0) {//Down
				isValid = true;
			}
		}
		return isValid;
	}

}

