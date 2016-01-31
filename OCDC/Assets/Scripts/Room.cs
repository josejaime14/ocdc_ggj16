using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

	public Obstacle[] obstacles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isSolved(){
		foreach (Obstacle obstacle in obstacles) {
			if (!obstacle.isSolved ())
				return false;
		}
		return true;
	}
}
