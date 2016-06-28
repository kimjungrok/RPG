using UnityEngine;
using System.Collections;

public class pattern4 : MonoBehaviour {
	public GameObject FarMonster;
	Transform FirePoint;
	public float fps = 10;
	bool isSummon = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (Summon ());
		FirePoint = GameObject.FindWithTag ("FirePoint").transform;
		//Bullet = GameObject.FindGameObjectWithTag ("bullet");
	}

	IEnumerator Summon() {

		while (true) {
			if (isSummon == false) {
				yield return null;
			} else {
				Instantiate (FarMonster, FirePoint.position, FirePoint.rotation);
				yield return new WaitForSeconds (1 / fps);
			}
		}
	}

	void OnTriggerStay(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isSummon = true;
		}
	}

	void OnTriggerExit(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isSummon = false;
		}
	}

}

