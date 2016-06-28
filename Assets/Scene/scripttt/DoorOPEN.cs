using UnityEngine;
using System.Collections;

public class DoorOPEN : MonoBehaviour {

	//GameObject Key;
	public float pushPower = 5.0f;

	// Use this for initialization
	void Start () {
		//Key = GameObject.FindGameObjectWithTag ("key");
	}
	/*
	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.gameObject.tag == "key") {
			//rigidbody.AddForce
		}
	}
	*/
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;

		if (body == null || body.isKinematic)
			return;

		if (hit.gameObject.tag == "moveable")
		{
			Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
			body.velocity = pushDir * pushPower;
		}
	}
		
	// Update is called once per frame
	void Update () {
	}
}