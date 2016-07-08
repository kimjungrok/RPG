using UnityEngine;
using System.Collections;

public class BossPattern2 : MonoBehaviour {

	public GameObject Pattern1;
	public float WaitingTime1;
	public GameObject Pattern2;
	public float WaitingTime2;
	public GameObject Pattern3;
	public float WaitingTime3;
	public GameObject Pattern4;
	public float WaitingTime4;
	public GameObject Pattern5;
	public float WaitingTime5;
	public GameObject Pattern6;
	public float WaitingTime6;
	public GameObject Pattern7;
	public float WaitingTime7;
	public GameObject Pattern8;
	public float WaitingTime8;
	public GameObject Pattern9;
	public float WaitingTime9;

	Animator aniCon;

	public GameObject NextBoss;


	//public List<GameObject> ListPattern;
	//[Range(0,1)]
	//public float testHP;

	float BossHPPercent;


	// Use this for initialization
	void Start () {
		BossHPPercent = GetComponent<MonsterManager> ().MonsterCurrentHP / GetComponent<MonsterManager> ().MonsterMaxHP;

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

		StartCoroutine (BossPatternManager2(5f));
		aniCon = GetComponent<Animator> ();
	}

	IEnumerator BossPatternManager2(float RegTime){
		yield return new WaitForSeconds (WaitingTime1);
		aniCon.SetTrigger ("IsBossPatternCast");
		Instantiate (Pattern1, Pattern1.transform.position, Pattern1.transform.rotation);
		Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);



		yield return new WaitForSeconds (WaitingTime2);

		aniCon.SetTrigger ("IsBossPatternCast");
		Instantiate (Pattern2, Pattern2.transform.position, Pattern2.transform.rotation);
		Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);


		yield return new WaitForSeconds (WaitingTime3);
		aniCon.SetTrigger ("IsBossPatternCast");
		Instantiate (Pattern1, Pattern1.transform.position, Pattern1.transform.rotation);
		Instantiate (Pattern4, Pattern4.transform.position, Pattern4.transform.rotation);


		yield return new WaitForSeconds (WaitingTime4);

		aniCon.SetTrigger ("IsBossPatternCast");
		Instantiate (Pattern2, Pattern2.transform.position, Pattern2.transform.rotation);
		Instantiate (Pattern6, Pattern6.transform.position, Pattern6.transform.rotation);




		yield return new WaitForSeconds (WaitingTime5);
		aniCon.SetTrigger ("IsBossPatternCast");
		Instantiate (Pattern5, Pattern5.transform.position, Pattern5.transform.rotation);


		yield return new WaitForSeconds (WaitingTime6);
		aniCon.SetTrigger ("IsBossPatternCast");
		Instantiate (Pattern7, Pattern7.transform.position, Pattern7.transform.rotation);


		yield return new WaitForSeconds (WaitingTime7);
		aniCon.SetTrigger ("IsBossPatternCast");
		Instantiate (Pattern8, Pattern8.transform.position, Pattern8.transform.rotation);


		yield return new WaitForSeconds (WaitingTime8);
		aniCon.SetTrigger ("IsBossPatternCast");
		Instantiate (Pattern9, Pattern9.transform.position, Pattern9.transform.rotation);
		Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);


		StartCoroutine (BossPatternManager2 (5f));
	}



	// Update is called once per frame
	void Update () {

		if (BossHPPercent <= 0) {
			Instantiate (NextBoss, this.gameObject.transform.position, this.gameObject.transform.rotation);
			Destroy (gameObject, 0.5f);

		}
	}
}
