using UnityEngine;
using System.Collections;

public class GiantMonsterlookable : MonoBehaviour {

	GameObject player;
	GameObject GiantMonsterlook;
	public RaycastHit hit;
	public bool IsHit = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		GiantMonsterlook = GameObject.FindGameObjectWithTag ("GiantOneLookpoint");
	}

	// Update is called once per frame
	void Update ()
	{
		if (Physics.Raycast (GiantMonsterlook.transform.position, GiantMonsterlook.transform.forward, out hit, 30.0f)) {
			if (hit.collider.tag == "Player"){
				IsHit = true;
			}
		}
		if (IsHit) {
			DestroyObject (player);
		}
			
	}
}