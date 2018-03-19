using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject 		respawnPoint;
	private Player1Movement 	Player1;
	private Player2Movement 	Player2;
	public Rigidbody 			rigid1;
	public Rigidbody 			rigid2;
	public GameObject 		deathParticle;
	public float			respawnDelay;
	
	// Use this for initialization
	void Start () {
		//Finds the players
		Player1 = FindObjectOfType <Player1Movement> ();
		Player2 = FindObjectOfType <Player2Movement> ();
		rigid1 = Player1.GetComponent<Rigidbody> ();
		rigid2 = Player2.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//calls Coroutine 
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo(){
		//Disables player movement
		Player1.enabled = false;
		Player2.enabled = false;
		//Set respawn delay
		yield return new WaitForSeconds (respawnDelay);
		//Set the spawn position of each player
		Vector3 spawnPos = respawnPoint.transform.position;
		Vector3 Player1Spawn = new Vector3 (spawnPos.x - 2, spawnPos.y - 3, spawnPos.z);
		Vector3 Player2Spawn = new Vector3 (spawnPos.x + 2, spawnPos.y - 3, spawnPos.z);
		//Move players to their resawn position
		Player1.transform.position = Player1Spawn;
		Player2.transform.position = Player2Spawn;
		//Set both player's velocties to 0
		Vector3 rigid1 = new Vector3 (0, 0, 0);
		Vector3 rigid2 = new Vector3 (0, 0, 0);
		//Re-enable player movement
		Player1.enabled = true;
		Player2.enabled = true;
	}
}

