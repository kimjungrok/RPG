using UnityEngine;
using System.Collections;

public class FireInTheHole : MonoBehaviour {
	public GameObject TinCan;
	Transform GiantMonsterlook;
	public float fps = 10;
	bool isfire = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (Fire ());
		GiantMonsterlook = GameObject.FindWithTag ("GiantOneLookpoint").transform;
	}

	IEnumerator Fire() {
		while (true) {
			if (isfire == false) {
				yield return null;
			} else {
				Instantiate (TinCan, GiantMonsterlook.position, GiantMonsterlook.rotation);
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

