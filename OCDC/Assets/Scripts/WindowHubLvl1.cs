using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Obstacle))]
public class WindowHubLvl1 : MonoBehaviour {

	public WindowLvl1[] windows;

	private int values;
	private Obstacle obstacle;
	private MainGameController mainController;

	// Use this for initialization
	void Start () {
		obstacle = GetComponent<Obstacle> ();
		mainController = (MainGameController) GameObject.FindObjectOfType (typeof(MainGameController));
		values = 0;
		foreach (WindowLvl1 window in windows) {
			if (window.isClosed)
				values++;
		}
	}
	
	public void UpdateValues(bool isClosed){
		if (isClosed)
			values++;
		else
			values--;
		
		if (values == windows.Length) {
			//mainController.addObstacleSolved ();
			obstacle.solved ();
		} else {
			obstacle.notSolved ();
		}
	}
}
