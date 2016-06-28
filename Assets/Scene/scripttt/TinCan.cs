using UnityEngine;
using System.Collections;

public class TinCan : MonoBehaviour {
	
	public float speed;
	public Rigidbody rigid;
	public GameObject trap;

	// Use this for initialization
	void Start () {
		trap = GameObject.FindGameObjectWithTag("Trap");
		rigid = GetComponent<Rigidbody> ();
		rigid.velocity = transform.forward * speed;
	}


	// Update is called once per frame
	void Update () {
		if(trap == null)
			rigid.velocity += new Vector3 (0f, -0.3f, 0f);
	}
}

