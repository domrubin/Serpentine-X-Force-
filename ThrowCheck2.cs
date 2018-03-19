using UnityEngine;
using System.Collections;

public class ThrowCheck2 : MonoBehaviour {

	public Player1Movement 	player1;
	public Player2Movement 	player2;
	public GameObject			player1GameObject;
	public GameObject			player2GameObject;
	public Rigidbody 			rigid1;
	public Rigidbody 			rigid2;
	public bool 				isThrowable;
	
	// Use this for initialization
	void Start () {
		//Set variables
		player1 = FindObjectOfType <Player1Movement> ();
		player2 = FindObjectOfType <Player2Movement> ();
		rigid1 = player1.GetComponent<Rigidbody> ();
		rigid2 = player2.GetComponent<Rigidbody> ();
		player1GameObject = player1.gameObject;
		player2GameObject = player2.gameObject;
		isThrowable = false;
	}
	
	void OnTriggerEnter (Collider other) {
		//If the isThrowable collider detects Player 2...
		if (other.name == "Player1") {
			//set is Throwable to true
			isThrowable = true;
			player2.canPull = false;
			player1.canPull = false;
		}
	}
	void OnTrigger (Collider other) {
		//If the isThrowable collider detects Player 2...
		if (other.name == "Player1") {
			//set canPull to false on both Players
			player2.canPull = false;
			player1.canPull = false;
		}
	}
	void OnTriggerExit (Collider other){
		//If the player moves out of the collider, set isThrowable to false
		isThrowable = false;
		player2.canPull = true;
		player1.canPull = true;
	}
	
	void Update() {
		if (isThrowable == true) {
			//If Player 1 is on top of Player 2...
			if (Input.GetKey ("[1]")) {
				//If Player 2 presses the enter key...
				rigid1.velocity = new Vector2 (rigid1.velocity.x, 10);
				//throw Player 1 upwards and set isThrowable to false
				isThrowable = false;
				GetComponent<AudioSource>().Play();
			}
		}
		//If Player 1 jumos, set isThrowable to false
		if (Input.GetKey (KeyCode.W)) {
			isThrowable = false;
		}
	}

	void FixedUpdate() {
		//If Player 1 is on top of Player 2...
		if (isThrowable == true) {
			//Set Player 1's velocity to Player 2's velocity
			rigid1.velocity = new Vector3 (rigid2.velocity.x, rigid2.velocity.y, rigid2.velocity.z);
		}
	}
}
