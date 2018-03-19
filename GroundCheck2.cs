using UnityEngine;
using System.Collections;

public class GroundCheck2 : MonoBehaviour {
	private Player2Movement player;
	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Player2Movement> ();
	}
	void OnTriggerEnter(Collider GroundCheck) {
		Player2Movement.grounded = true;
		
	}
	
	void OnTriggerExit (Collider GroundCheck) {
	}
	// Update is called once per frame
	void Update () {
		
	}
}
