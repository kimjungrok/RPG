using UnityEngine;
using System.Collections;

public class pattern1 : MonoBehaviour {
	public GameObject Bullet;
	Transform FirePoint;
	public float fps = 10;
	bool isfire = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (Shot ());
		FirePoint = GameObject.FindWithTag ("FirePoint").transform;
		//Bullet = GameObject.FindGameObjectWithTag ("bullet");
	}

	IEnumerator Shot() {
		
		while (true) {
			if (isfire == false) {
				yield return null;
			} else {
				Instantiate (Bullet, FirePoint.position, FirePoint.rotation);
				yield return new WaitForSeconds (1 / fps);
			}
		}
	}

	void OnTriggerStay(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isfire = true;
		}
	}

	void OnTriggerExit(Collider Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			isfire = false;
		}
	}

}

