using UnityEngine;
using System.Collections;

public class GroundCheck1: MonoBehaviour {

	private Player1Movement player;
	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Player1Movement> ();
	}
	void OnTriggerEnter(Collider GroundCheck) {
		if (!GroundCheck.gameObject.CompareTag ("JumpPad")) {
			Player1Movement.grounded = true;
		}

	}

	void OnTriggerExit (Collider GroundCheck) {
	}
	// Update is called once per frame
	void Update () {
	
	}
}
