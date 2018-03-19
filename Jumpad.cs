using UnityEngine;
using System.Collections;

public class Jumpad : MonoBehaviour {
	private Player1Movement 	player1;
	private Player2Movement 	player2;
	private Rigidbody rigid1;
	private Rigidbody rigid2;
	public int jumpheight;
	public int jumplength;
	// Use this for initialization
	void Start () {
		//Set variables
		player1 = FindObjectOfType <Player1Movement> ();
		player2 = FindObjectOfType <Player2Movement> ();
		rigid1 = player1.GetComponent<Rigidbody> ();
		rigid2 = player2.GetComponent<Rigidbody> ();
	}
	void OnTriggerEnter(Collider other) {
		//If the collider detects Player 1...
		if (other.name == "Player1") {
			//set its x and y velocity to the designated amount
			rigid1.velocity = new Vector3 (jumplength, jumpheight, 0);
			GetComponent<AudioSource>().Play();
		}
		//if the collider detects Player 2
		if (other.name == "Player2") {
			//Do the same for Player 2
			rigid2.velocity = new Vector3 (jumplength, jumpheight, 0);
			GetComponent<AudioSource>().Play();
		}
	}
}
