using UnityEngine;
using System.Collections;

public class WeaponSetactive : MonoBehaviour {

	BoxCollider col;
	public GameObject player;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}

	IEnumerator WeaponDisable(float DisableTime){
		yield return new WaitForSeconds (0.5f);
		this.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.gameObject == player) {
			
			this.gameObject.SetActive (true);
			WeaponDisable (0.5f);

		}
	}
	
	// Update is called once per frame
	void Update () {

		col.enabled = false;
	
	}
}
