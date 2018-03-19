using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour {

	public float 	jumpHeight = 			10f;
	public int 	fastFallMod = 			2;
	public static bool grounded;
	public Rigidbody p_RigidBody;
	private float 	p_Localx;
	private float p_Localy;
	public static bool facingRight = true;
	public bool isMoving = false;
	public int movementSpeed = 10;
	public static Transform p2pos;
	public float pulltime1;
	public float pulltime2;
	public float maxPull = 1f;
	public float pullCD = 3f;
	public bool canPull = true;
	public bool timerStart;
	
	// Use this for initialization
	void Awake () {
		p2pos = transform;
		p_RigidBody = GetComponent<Rigidbody>();
		pulltime1 = maxPull;
	}

	// Update is called once per frame
	void Update () {
		//assigning variables
		//p2pos = p_RigidBody.transform.position;

		p_Localx = GetComponent<Rigidbody>().velocity.x;
		p_Localy = GetComponent<Rigidbody>().velocity.y;
		//find axis values
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (h < 0) {
			facingRight = false;
		} else {
			facingRight = true;
		}
		//Horizontal movement
		if (Input.GetKey (KeyCode.RightArrow)) {
			//gameObject.transform.rotation.y = 0f;
			p_RigidBody.velocity = new Vector2 (movementSpeed, p_Localy);
			isMoving = true;
			transform.localScale = new Vector3 (1, 1, 1);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//gameObject.transform.rotation.y = 180f;
			p_RigidBody.velocity = new Vector2 (-movementSpeed, p_Localy);
			isMoving = true;
			transform.localScale = new Vector3 (-1, 1, 1);

		}
		//Stop sideways movement
		if (Input.GetKeyUp (KeyCode.RightArrow)||Input.GetKeyUp (KeyCode.LeftArrow) ) {
			isMoving = false;
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && grounded == true||Input.GetKeyUp (KeyCode.LeftArrow) && grounded == true) {
			p_RigidBody.velocity = new Vector2 (0, p_Localy);
		}
		if (grounded == true && Mathf.Abs (p_RigidBody.velocity.x) >= 0 && isMoving == false) {
			p_RigidBody.velocity = new Vector2 (0, p_Localy);
		}
		//Jump
		if (Input.GetKeyDown (KeyCode.UpArrow) && (grounded == true)) {
			p_RigidBody.velocity = new Vector2 (p_Localx, jumpHeight);
			grounded = false;
			GetComponent<AudioSource>().Play();
		}
		//Grapple
		if (timerStart == true) {
			pulltime2 -= Time.deltaTime;
		}
		if (pulltime2 < 0) {
			timerStart = false;
			pulltime2 = pullCD;
			pulltime1 = 1f;
			canPull = true;
		}
		if (pulltime1 < 0) {
			canPull = false;
		}
		if (canPull == false) {
			p_RigidBody.useGravity =  true;
		}
		
		if (Input.GetKey ("f") && canPull == true && Player1Movement.grounded == true) {
			this.p_RigidBody.velocity = new Vector2 (0,0);
			this.transform.position = Vector3.MoveTowards(p2pos.position, Player1Movement.p1pos.position, Player1Movement.pullForce);
			pulltime1 -= Time.deltaTime;
			timerStart = true;
		}
		if (Input.GetKeyDown ("f") && Player1Movement.grounded == true) {
			p_RigidBody.useGravity = false;
		}
		if (Input.GetKeyUp ("f") || pulltime1 < 0) {
			p_RigidBody.useGravity =  true;
		}	
	}
}
