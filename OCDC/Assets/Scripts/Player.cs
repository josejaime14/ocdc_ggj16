using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public static float insanity = 0;
	public float speed = 20;
	public float jumpForce = 200;
	public bool canWalk = false;

	private Rigidbody2D rigidBody;
	private bool canJump;
	private MainGameController mainController;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		mainController = (MainGameController) GameObject.FindObjectOfType (typeof(MainGameController));
		canJump = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(canWalk)
			rigidBody.velocity = new Vector2 (Time.deltaTime*speed,rigidBody.velocity.y);
	}

	void OnMouseDown() {
		if (canJump) {
			canJump = false;
			rigidBody.AddForce (new Vector2 (rigidBody.velocity.x,jumpForce));
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "door") {
			mainController.CheckRoom ();
		}

		if (coll.gameObject.tag == "floor") {
			canJump = true;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "tick") {
			anim.SetTrigger ("tick");
		}
	}
}
