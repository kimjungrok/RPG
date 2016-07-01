using UnityEngine;
using System.Collections;

public class BossAi : MonoBehaviour {

	NavMeshAgent agent;
	GameObject player;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {

		//Debug.Log (player.transform.position.ToString ());
		agent.SetDestination (player.transform.position);
	}
}