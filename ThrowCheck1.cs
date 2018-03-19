using UnityEngine;
using System.Collections;

public class ThrowCheck1 : MonoBehaviour {

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
		if (other.name == "Player2") {
			//set is Throwable to true
			isThrowable = true;
			player1.canPull = false;
			player2.canPull = false;
		}
	}
	void OnTrigger (Collider other) {
		//If the isThrowable collider detects Player 2...
		if (other.name == "Player2") {
			//set canPull to false on both Players
			player2.canPull = false;
			player1.canPull = false;
		}
	}
	void OnTriggerExit (Collider other){
		//If the player moves out of the collider, set isThrowable to false
		isThrowable = false;
		player1.canPull = true;
		player1.canPull = true;
	}

	void Update() {
		//If Player 2 is on top of Player 1...
		if (isThrowable == true) {
			//If Player 1 presses the space key...
			if (Input.GetKey (KeyCode.Space)) {
				//throw Player2 upwards and set isThrowable to false
				rigid2.velocity = new Vector2 (rigid2.velocity.x, 10);
				isThrowable = false;
				GetComponent<AudioSource>().Play();
			}
		}
		//If Player 2 jumos, set isThrowable to false
		if (Input.GetKey (KeyCode.UpArrow)) {
			isThrowable = false;
		}
	}
	void FixedUpdate() {
		//If Player 2 is on top of Player 1...
		if (isThrowable == true) {
			//Set Player 2's velocity to Player 1's velocity
			rigid2.velocity = new Vector3 (rigid1.velocity.x, rigid1.velocity.y, rigid1.velocity.z);
		}
	}
}
