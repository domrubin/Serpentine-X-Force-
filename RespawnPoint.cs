using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour {

	public LevelManager		levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType <LevelManager> ();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player1" || other.tag == "Player2") {
			levelManager.respawnPoint = gameObject;
			Debug.Log ("Activated Checkpoint " + transform.position);
		}
	}
}
