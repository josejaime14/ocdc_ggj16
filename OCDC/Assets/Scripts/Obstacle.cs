using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {


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
	}
}
