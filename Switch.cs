using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public Player1Movement 	player1;
	public Player2Movement 	player2;
	public bool				switchActive = false;
	public bool 			near1 = false;
	public bool 			near2 = false;
	public GameObject		door;
	public Vector3			doorPos;
	public GameObject 		doorGoal;
	// Use this for initialization
	void Start () {
		//Set variables
		doorPos = door.transform.position;
		player1 = FindObjectOfType <Player1Movement> ();
		player2 = FindObjectOfType <Player2Movement> ();
	}

	void OnTriggerEnter (Collider other) {
		//If Player 1 enters the collider
		if (other.tag == "Player1") {
			//Say so and set near1 to true
			Debug.Log ("Player 1 near Switch");
			near1 = true;
		}
		//If Player 2 enters the collider
		if (other.tag == "Player2") {
			//Say so and set near2 to true
			Debug.Log ("Player 2 near Switch");
			near2 = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player1") {
			near1 = false;
		}
		if (other.tag == "Player2") {
			near2 = false;
		}
	}
	// Update is called once per frame
	void Update () {

		if (near1 == true) {
			//if Player 1 presses G near the switch...
			if (Input.GetKeyDown (KeyCode.G)){
				switchActive = !switchActive;
				GetComponent<AudioSource>().Play();
			}
		}
		if (near2 == true) {
			//if Player 2 presses enter near the switch
			if (Input.GetKeyDown ("[2]")) {
				switchActive = !switchActive;
				GetComponent<AudioSource>().Play();
			}
		}


		//set the door's original position
		Vector3 spawnPos = door.transform.position;
		//If the Switch is active
		if (switchActive == true) {
			//set Door's position to it's Goal's position
			door.transform.position = doorGoal.transform.position;
		} 
		if (switchActive == false){
			door.transform.position = doorPos;
		}
	}
}
