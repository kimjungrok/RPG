using UnityEngine;
using System.Collections;

public class specialenemy2 : MonoBehaviour
{
	NavMeshAgent agent;
	GameObject player;
	GameObject specialEnemy2;

	public bool isChase = false;

	// Use this for initialization

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		specialEnemy2 = GameObject.FindGameObjectWithTag ("specialenemy2");
	}


	/*
		void OnTriggerStay(Collider Coll)
	{
		if ( (Coll.gameObject.tag == "lookpoint"))
		{
			isChase = false;
		}
	}
	void OnTriggerExit(Collider Coll)
	{
		if (Coll.gameObject.tag == "lookpoint") {
		isChase = true;
		}
	}*/


	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance (player.transform.position, specialEnemy2.transform.position) <= 100.0f) {
			isChase = true;
		}
		else
			isChase = false;

		if (Mathf.Abs (Vector3.Angle (player.transform.forward, specialEnemy2.transform.position - player.transform.position)) <= 35.0f)
			isChase = false;


		//Debug.Log (isChase);

		if (isChase) {
			Vector3 targetPos = player.transform.position;
			agent.Resume ();
			agent.SetDestination (targetPos);

		} else {			
			agent.Stop();
			//agent.SetDestination (player.transform.position);
		}



	}
}
