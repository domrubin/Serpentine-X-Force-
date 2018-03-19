using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public Camera mainCam;
	public Transform player1;
	public Transform player2;
	public float minSizeY = 5f;
	public float cameraMarginsX = 6f;
	public float cameraMarginsY = 3f;
	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 poi = (player1.position + player2.position) / 2;
		poi.z = -10;
		transform.position = poi;
		if (Mathf.Abs (player1.position.y - player2.position.y) > 16) {
			Zoom ();
		}
		if (Mathf.Abs (player1.position.x - player2.position.x) > 28) {
			Zoom ();
		}
	}

	void Zoom() {
			//horizontal size is based on actual screen ratio
			float minSizeX = minSizeY * Screen.width / Screen.height;
			//multiplying by 0.5, because the ortographicSize is actually half the height
			float width = (Mathf.Abs(player1.position.x - player2.position.x ) + cameraMarginsX) * 0.5f;
			float height = (Mathf.Abs(player1.position.y - player2.position.y) + cameraMarginsY) * 0.5f;
			//computing the size
			float camSizeX = Mathf.Max(width, minSizeX);
			Camera.main.orthographicSize = Mathf.Max(height,
			                                    camSizeX * Screen.height / Screen.width, minSizeY);
	}

	// http://answers.unity3d.com/questions/674225/2d-camera-to-follow-two-players.html
}
