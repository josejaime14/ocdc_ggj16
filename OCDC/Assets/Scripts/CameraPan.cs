using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {


	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < 0)
			transform.position += Vector3.right * Time.deltaTime * speed;
	}	
}
