using UnityEngine;
using System.Collections;

public class bossTrailer : MonoBehaviour {

	GameObject player;
	Transform transform;
	GameObject ThisisBoss;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		transform = GetComponent<Transform> ();
		ThisisBoss = GameObject.FindGameObjectWithTag ("bossmonster");


	}

	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + new Vector3 (50, -100f, 170);

	}
}