using UnityEngine;
using System.Collections;

public class SkillEffect : MonoBehaviour {


	public float runningTime = 0f;


	void Start () {
	
		StartCoroutine (destory ());
	}
	
	// Update is called once per frame
	IEnumerator destory(){

		yield return new WaitForSeconds (runningTime);
		Destroy (gameObject);

	}
}
