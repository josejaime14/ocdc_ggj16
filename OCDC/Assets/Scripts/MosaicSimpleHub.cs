using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Obstacle))]
public class MosaicSimpleHub : MonoBehaviour {

	public MosaicSimple[] mosaics;

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
		int lastValue = mosaics [0].value;
		for (int i = 1; i < mosaics.Length; i++) {
			if (lastValue == mosaics [i].value) {
				values++;
			} else {
				break;
			}
			lastValue = mosaics [i].value;

		}
		//Debug.Log ("values: " + values);
		if ((values == (mosaics.Length - 1))) {
			//mainController.addObstacleSolved ();
			obstacle.solved ();
		} else {
			obstacle.notSolved ();
		}
	}
}
