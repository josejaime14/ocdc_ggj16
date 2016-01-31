using UnityEngine;
using System.Collections;

public class MosaicSimple : MonoBehaviour {

	public int value;

	private MosaicSimpleHub hub;
	private Animator anim;

	// Use this for initialization
	void Start () {
		hub = transform.parent.GetComponent<MosaicSimpleHub> ();
		anim = GetComponent<Animator> ();
		anim.SetInteger ("value", value);
	}

	void OnMouseDown() {

		if (value < 4)
			value++;
		else
			value = 1;
		
		anim.SetTrigger ("turn");
		hub.CheckValues ();

	}
}
