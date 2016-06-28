using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour {


	Animator aniCon;

	GameObject player;
	GameObject lookpoints;

	CharacterController con;
	public float speed = 6;
	public float jumpspeed = 8;
	public float gravity = 20;
	public float rotationspeed = 2;
	Vector3 move = Vector3.zero;

	// Use this for initialization
	void Start () {
		con = GetComponent<CharacterController> ();
		player = GameObject.FindWithTag ("Player");
		aniCon = GetComponent<Animator> ();
		lookpoints = GameObject.FindWithTag("lookpoint");

		//Cursor.lockState = CursorLockMode.Locked;
	}
	// Update is called once per frame

	void Update () {


		
		if (con.isGrounded) {
			move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical") );
			move = transform.TransformDirection (move);
			move *= speed;

			if (Input.GetButton ("Jump")) {
				move.y = jumpspeed;
			}
		}

		move.y -= gravity * Time.deltaTime;
		con.Move (move * Time.deltaTime);

		//transform.LookAt(lookpoints.transform.position);
	
			
		if ( (Input.GetAxis ("Horizontal") != 0f) || (Input.GetAxis ("Vertical") != 0f) )
			aniCon.SetBool ("IsWalk", true);
		else
			aniCon.SetBool ("IsWalk", false);


		if (Input.GetAxis ("Jump") != 0)
			aniCon.SetBool ("IsJump", true);
		else
			aniCon.SetBool ("IsJump", false);
		

		//if (Input.anyKeyDown == true) {
		//	player.transform.eulerAngles = new Vector3 (player.transform.eulerAngles.x, 0, player.transform.eulerAngles.z);
		//}
		

		var rotation = new Vector3 (0, Input.GetAxis("Horizontal") * rotationspeed, 0f );
		rotation += transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler (rotation);


		/*
		var rotation = new Vector3 (-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * rotationspeed;
		rotation += transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler (rotation);
		*/


	}
	/*
	void Turn ()
	{
		Quaternion newRotation = Quaternion.LookRotation (move);

		con.
		*/

}
