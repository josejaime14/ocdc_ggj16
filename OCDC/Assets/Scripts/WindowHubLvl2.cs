using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Obstacle))]
public class WindowHubLvl2 : MonoBehaviour
{
	public WindowLvl2[] windows;

	private int values;
	private Obstacle obstacle;
	private MainGameController mainController;

	// Use this for initialization
	void Start () {
		obstacle = GetComponent<Obstacle> ();
		mainController = (MainGameController) GameObject.FindObjectOfType (typeof(MainGameController));

	}

	public void CheckValues(){

		values = 0;
		foreach (WindowLvl2 window in windows) {
			if (window.isValid ())
				values++;
		}

		if (values == windows.Length) {
			//mainController.addObstacleSolved ();
			obstacle.solved ();
		}
	}
}

