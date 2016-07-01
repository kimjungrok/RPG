using UnityEngine;
using System.Collections;

public class cameramove : MonoBehaviour {

	GameObject player;
	Transform transform;
	GameObject maincamera;



	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		transform = GetComponent<Transform> ();

		//maincamera = GameObject.FindWithTag ("MainCamera");
		//transform.rotation = maincamera.transform.rotation + new Vector3 (35, 0, 0);


	}
	// Update is called once per frame

	void Update () {


		transform.position = player.transform.position + new Vector3 (0, 135, -100);




	}





}
	/*
	void Turn ()
	{
		Quaternion newRotation = Quaternion.LookRotation (move);

		con.
		*/
