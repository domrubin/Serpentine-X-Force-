using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManager 	levelManager;
	
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player1" || other.tag == "Player2") {
			Debug.Log ("Player Has Been Killed");
			levelManager.RespawnPlayer ();
		}
	}
}
