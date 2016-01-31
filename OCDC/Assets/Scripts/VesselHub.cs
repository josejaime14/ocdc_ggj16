using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Obstacle))]
public class VesselHub : MonoBehaviour {

	public Vessel[] vessels;
	public int[] answer;

	private int values;
	private Obstacle obstacle;
	private MainGameController mainController;
	private bool solved;

	// Use this for initialization
	void Start () {
		obstacle = GetComponent<Obstacle> ();
		values = 0;

	}


	public void Shift (int pos1, int pos2) {
		int index1 = 0, index2 = 0;

		for (int i = 0; i < vessels.Length; i++) {
			if (vessels [i].position == pos1) {
				index1 = i;
				break;
			}
				
		}

		for (int i = 0; i < vessels.Length; i++) {
			if (vessels [i].position == pos2) {
				index2 = i;
				break;
			}	
		}

		vessels [index1].position = pos2;
		vessels [index2].position = pos1;

		solved = true;
		for (int i = 0; i < vessels.Length; i++) {
			if (vessels [i].value != answer[vessels [i].position-1]) {
				solved = false;
				break;
			}	
		}
		if (solved)
			obstacle.solved ();
		else
			obstacle.notSolved ();


	}
}
