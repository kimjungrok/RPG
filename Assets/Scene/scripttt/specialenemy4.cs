using UnityEngine;
using System.Collections;

public class specialenemy4 : MonoBehaviour
	{
		NavMeshAgent agent;
		GameObject player;
		GameObject specialEnemy4;

		public bool isChase = false;

		// Use this for initialization

		void Start ()
		{
			agent = GetComponent<NavMeshAgent> ();
			player = GameObject.FindGameObjectWithTag ("Player");
			specialEnemy4 = GameObject.FindGameObjectWithTag ("specialenemy4");
		}


		// Update is called once per frame
		void Update ()
		{
			if (Vector3.Distance (player.transform.position, specialEnemy4.transform.position) <= 100.0f) {
				isChase = true;
			}
			else
				isChase = false;

			if (Mathf.Abs (Vector3.Angle (player.transform.forward, specialEnemy4.transform.position - player.transform.position)) <= 35.0f)
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
