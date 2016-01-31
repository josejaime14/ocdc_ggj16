using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Obstacle))]
public class SwitchHub : MonoBehaviour {

	public Switch[] switches;

	private int values;
	private Obstacle obstacle;
	private MainGameController mainController;

	// Use this for initialization
	void Start () {
		obstacle = GetComponent<Obstacle> ();
		mainController = (MainGameController) GameObject.FindObjectOfType (typeof(MainGameController));
		values = 0;
		foreach (Switch sw in switches) {
			if (sw.value)
				values++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateValues(bool value){
		if (value)
			values++;
		else
			values--;
		Debug.Log ("values: " + values);
		if ((values == switches.Length || values == 0) && !obstacle.isSolved()) {
			mainController.addObstacleSolved ();
			obstacle.solved ();
		}
	}
}
