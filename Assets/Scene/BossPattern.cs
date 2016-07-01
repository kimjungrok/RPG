using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossPattern : MonoBehaviour {

	public GameObject Pattern1;
	public GameObject Pattern2;
	public GameObject Pattern3;
	public GameObject Pattern4;
	public GameObject Pattern5;
	public GameObject Pattern6;
	public GameObject Pattern7;
	public GameObject Pattern8;
	public GameObject Pattern9;
	//public List<GameObject> ListPattern;
	//[Range(0,1)]
	//public float testHP;

	// Use this for initialization
	void Start () {
		/*
		Pattern1.gameObject.SetActive (false);
		Pattern2.gameObject.SetActive (false);
		Pattern3.gameObject.SetActive (false);
		Pattern4.gameObject.SetActive (false);
		Pattern5.gameObject.SetActive (false);
		Pattern6.gameObject.SetActive (false);
		Pattern7.gameObject.SetActive (false);
		Pattern8.gameObject.SetActive (false);
		Pattern9.gameObject.SetActive (false);
*/

		StartCoroutine (BossPatternManager(5f));
	
	}

	IEnumerator BossPatternManager(float RegTime)
	{
		if (GetComponent<MonsterManager> ().MonsterMaxHP/GetComponent<MonsterManager> ().MonsterCurrentHP > 0.7f) {
			yield return new WaitForSeconds (5);

			Pattern1.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);

			Pattern2.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			Pattern3.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			Pattern4.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			Pattern5.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			Pattern6.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			Pattern7.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			Pattern8.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			Pattern9.gameObject.SetActive (true);

			StartCoroutine (BossPatternManager (5f));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
