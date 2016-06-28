using UnityEngine;
using System.Collections;

public class ai : MonoBehaviour {

	NavMeshAgent agent;
	GameObject player;

	bool isChase = false;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerStay(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isChase = true;
		}
	}

	void OnTriggerExit(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isChase = false;
		}
	}
	// Update is called once per frame
	void Update () {

		if (isChase) {
			agent.SetDestination (player.transform.position);
		}
	}
}
