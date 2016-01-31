using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
	public Room room;
	public Player player;
	public MeshRenderer insanityDistort;
	public Image transitionImage;
	public string nextLevel;

	private int solvedObstacles;
	private bool isGameOver;

	// Use this for initialization
	void Start (){
		isGameOver = false;
		solvedObstacles = 0;
		insanityDistort.material.SetVector ("_IntensityAndScrolling", new Vector4 (Player.insanity, Player.insanity, 0.1f, 0.2f));
		StartCoroutine (AwakePlayer ());
	}
	
	// Update is called once per frame
	void Update (){
		if (room.isSolved () && !isGameOver)
			EndRoom ();
	}

	void EndRoom(){
		isGameOver = true;
		player.speed *= 3;
		Player.insanity = 0.0f;
		StartCoroutine(EndTransition(1.0f));
	}

	public void removeObstacleSolved(){
		solvedObstacles--;
	}

	public void CheckRoom(){
		if (room.isSolved ()) {
			//LoadNextLevel and reset insanity
			Player.insanity = 0.0f;
			StartCoroutine(EndTransition(1.0f));
		}else{
			//RepeatLevel + insanity
			Application.LoadLevel (Application.loadedLevel);
			Player.insanity += 0.005f;
		}
	}

	IEnumerator AwakePlayer(){
		yield return new WaitForSeconds (1.2f);
		player.canWalk = true;
	}

	IEnumerator EndTransition(float delay){
		yield return new WaitForSeconds (delay);
		transitionImage.GetComponent<Animator> ().SetTrigger ("toDark");
		StartCoroutine(LoadNextLevel(1.0f));
	}

	IEnumerator LoadNextLevel(float delay){
		yield return new WaitForSeconds (delay);
		Application.LoadLevel (nextLevel);
	}
}

