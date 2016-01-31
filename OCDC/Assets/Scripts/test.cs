using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "pos : " + transform.position.x + " rot : " + transform.rotation.z;
	}
}
