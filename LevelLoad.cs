using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {

	private bool		player1InZone;
	private bool		player2InZone;

	public string		levelToLoad;
	
	// Use this for initialization
	void Start () {
		player1InZone = false;
		player2InZone = false;
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player1") {
			player1InZone = true;
		}
		if (other.tag == "Player2") {
			player2InZone = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.name == "Player") {
			player1InZone = false;
			player1InZone = false;
		}
	}

	void Update (){
	if (player1InZone == true && player2InZone == true){
			Application.LoadLevel (levelToLoad);
		}
	}
}