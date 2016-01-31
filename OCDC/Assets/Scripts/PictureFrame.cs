using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Obstacle))]
public class PictureFrame : MonoBehaviour
{
	private Animator anim;
	private Obstacle obstacle;
	private MainGameController mainController;

	// Use this for initialization
	void Start (){
		anim = GetComponent<Animator> ();
		obstacle = GetComponent<Obstacle> ();
		mainController = (MainGameController) GameObject.FindObjectOfType (typeof(MainGameController));
	}

	void OnMouseDown() {
		if (!obstacle.isSolved()) {
			anim.SetBool ("solved", true);
			obstacle.solved ();
			mainController.addObstacleSolved ();
		}

	}
}

