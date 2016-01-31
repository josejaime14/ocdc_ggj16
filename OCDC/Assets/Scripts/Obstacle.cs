using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public BoxCollider2D tickTrigger;

	private bool finished;

	// Use this for initialization
	void Start () {
		
		finished = false;
	}


	public bool isSolved(){
		return finished;
	}

	public void solved(){
		finished = true;
		tickTrigger.enabled = false;
	}

	public void notSolved(){
		finished = false;
		tickTrigger.enabled = true;
	}
}
