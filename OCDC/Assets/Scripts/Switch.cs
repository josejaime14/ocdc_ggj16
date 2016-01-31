using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public bool value;

	private SwitchHub hub;
	private Animator anim;

	// Use this for initialization
	void Start () {
		hub = transform.parent.GetComponent<SwitchHub> ();
		anim = GetComponent<Animator> ();
		anim.SetBool ("value", value);
	}
	
	void OnMouseDown() {
		if (value)
			value = false;
		else
			value = true;
		
		hub.UpdateValues (value);
		anim.SetBool ("value", value);
	}


}
