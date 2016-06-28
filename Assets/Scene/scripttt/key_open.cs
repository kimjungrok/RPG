using UnityEngine;
using System.Collections;

public class key_open : MonoBehaviour {

	GameObject player;
	Transform transform;
	GameObject ThisisKey;
	public bool ishavekey = false;



	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		transform = GetComponent<Transform> ();
		ThisisKey = GameObject.FindGameObjectWithTag ("Key");


	}

	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			ishavekey = true;
		}
	}


	// Update is called once per frame
	void Update () {

		if (ishavekey) {
			transform.position = player.transform.position + new Vector3 (1, 7, 1);
		}


	}



}