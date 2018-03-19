using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {
	
	public static Transform p1pos;
	public float 	speedModifier = 		5f;
	public float 	jumpHeight = 			10f;
	public int 	fastFallMod = 			2;
	public static bool grounded;
	public Rigidbody p_RigidBody;
	private float 	p_Localx;
	private float p_Localy;
	public static bool facingRight = true;
	public bool isMoving = false;
	public static float pullForce = 0.17f;
	public LineRenderer serpent;
	public float pulltime1;
	public float pulltime2;
	public float maxPull = 1f;
	public float pullCD = 3f;
	public bool canPull = true;
	public bool timerStart = false;



	// Use this for initialization
	void Awake () {
		p1pos = transform;
		p_RigidBody = GetComponent<Rigidbody>();
		pulltime1 = maxPull;
	}
	
	// Update is called once per frame
	void Update () {
		//assigning variables

		p_Localx = GetComponent<Rigidbody>().velocity.x;
		p_Localy = GetComponent<Rigidbody>().velocity.y;
		//p1pos = p_RigidBody.transform.position;
		//find axis values
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (h < 0) {
			facingRight = false;
		} else {
			facingRight = true;
		}
		//Horizontal movement
		if (Input.GetButton ("Horizontal")) {
			p_RigidBody.velocity = new Vector2 (h*speedModifier, p_Localy);
			isMoving = true;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			transform.localScale = new Vector3 (1, 1, 1);
		}
		//Stop sidewways movement
		if (Input.GetButtonUp ("Horizontal")) {
			isMoving = false;
		}
		if (Input.GetButtonUp ("Horizontal" ) && grounded == true) {
			p_RigidBody.velocity = new Vector2 (0, p_Localy);
		}
		if (grounded == true && Mathf.Abs (p_RigidBody.velocity.x) >= 0 && isMoving == false) {
			p_RigidBody.velocity = new Vector2 (0, p_Localy);
		}
		//Jump
		if (Input.GetButtonDown ("Jump") && grounded == true) {
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
			p_RigidBody.useGravity =  true;
		}

		if (Input.GetKey ("[0]") && canPull == true && Player2Movement.grounded == true) {
			this.p_RigidBody.velocity = new Vector2 (0,0);
			this.transform.position = Vector3.MoveTowards(p1pos.position, Player2Movement.p2pos.position, pullForce);
			pulltime1 -= Time.deltaTime;
			timerStart = true;
		}
		if (Input.GetKeyDown ("[0]")) {
			p_RigidBody.useGravity = false;
		}
		if (Input.GetKeyUp ("[0]") || pulltime1 < 0) {
			p_RigidBody.useGravity =  true;
		}

		serpent.SetPosition (0, transform.position);
		serpent.SetPosition (1, Player2Movement.p2pos.transform.position);
	}
}
