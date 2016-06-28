using UnityEngine;
using System.Collections;

public class openthedoor : MonoBehaviour {

	GameObject ThisisKey;
	public bool shehavekey = false;
	//GameObject ThisisDoor;


	// Use this for initialization
	void Start () {
		ThisisKey = GameObject.FindGameObjectWithTag ("Key");
		//ThisisDoor = GameObject.FindGameObjectWithTag ("Door");
	}

	void OnTriggerEnter(Collider keeeyyy)
	{
		if (keeeyyy.gameObject.tag == "Key") {
			shehavekey = true;
			//Destroy (gameObject);
			//DestroyObject (ThisisKey);
		}
	}


	// Update is called once per frame
	void Update () {

		if (shehavekey) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0f, 0), Time.deltaTime);
			//transform.rotation =Quaternion.Euler (0, 0f, 0);

			//Destroy (gameObject);
			DestroyObject (ThisisKey);
		}
	}
}