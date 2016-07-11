using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossPattern : MonoBehaviour {

	/*
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
*/
	Animator aniCon;

	//public GameObject NextBoss;


	public List<MonsterPatternInfo> listPattern;

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

		StartCoroutine (BossPatternManager1(5f));
		aniCon = GetComponent<Animator> ();
	}
	/*
	void HPcheak(){
		if (BossHPPercent < 0.7f) {
			
			StopCoroutine (BossPatternManager1 (5f));

			StartCoroutine (BossPatternManager2 (5f));
			enabled = false;
		}
	}*/

	IEnumerator BossPatternManager1(float RegTime)
	{
		//if (BossHPPercent >= 0.7f) { //for문 써서 수정하려면 패턴 담는 공간이 없어짐

		foreach (MonsterPatternInfo info in listPattern) {
			
			yield return new WaitForSeconds (info.waitTime);
			aniCon.SetTrigger ("IsBossPatternCast");
			Instantiate (info.objPattern, transform.position, info.objPattern.transform.rotation);
		}
		/*
		yield return new WaitForSeconds (WaitingTime1);

		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern1, Pattern1.transform.position, Pattern1.transform.rotation);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);

		//Pattern1.gameObject.SetActive (true);

		yield return new WaitForSeconds (WaitingTime2);
		//HPcheak ();
		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern2, Pattern2.transform.position, Pattern2.transform.rotation);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);
		//Pattern2.gameObject.SetActive (true);

		yield return new WaitForSeconds (WaitingTime3);
		//HPcheak ();
		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);
		//Pattern3.gameObject.SetActive (true);

		yield return new WaitForSeconds (WaitingTime4);
		//HPcheak ();
		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern4, Pattern4.transform.position, Pattern4.transform.rotation);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);
		//Pattern4.gameObject.SetActive (true);

		yield return new WaitForSeconds (WaitingTime5);
		//HPcheak ();
		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern5, Pattern5.transform.position, Pattern5.transform.rotation);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);
		//Pattern5.gameObject.SetActive (true);

		yield return new WaitForSeconds (WaitingTime6);
		//HPcheak ();
		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern6, Pattern6.transform.position, Pattern6.transform.rotation);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);
		//Pattern6.gameObject.SetActive (true);

		yield return new WaitForSeconds (WaitingTime7);
		//HPcheak ();
		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern7, Pattern7.transform.position, Pattern7.transform.rotation);
		yield return new WaitForSeconds (1f);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);
		//Pattern7.gameObject.SetActive (true);

		yield return new WaitForSeconds (WaitingTime8);
		//HPcheak ();
		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern8, Pattern8.transform.position, Pattern8.transform.rotation);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);
		//Pattern8.gameObject.SetActive (true);

		yield return new WaitForSeconds (WaitingTime9);
		//HPcheak ();
		aniCon.SetBool ("IsBossPattern", true);
		Instantiate (Pattern9, Pattern9.transform.position, Pattern9.transform.rotation);
		yield return new WaitForSeconds (1f);
		aniCon.SetBool ("IsBossPattern", false);
		//Pattern9.gameObject.SetActive (true);
		*/
		StartCoroutine (BossPatternManager1 (10f));
	}

		//}
		/* else if ((0.25f < BossHPPercent) && (BossHPPercent < 0.7f)) {
	
			yield return new WaitForSeconds (WaitingTime1);

			Instantiate (Pattern1, Pattern1.transform.position, Pattern1.transform.rotation);
			Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);
			//Pattern1.gameObject.SetActive (true);

			yield return new WaitForSeconds (WaitingTime2);


			Instantiate (Pattern2, Pattern2.transform.position, Pattern2.transform.rotation);
			Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);

			yield return new WaitForSeconds (WaitingTime3);

			Instantiate (Pattern1, Pattern1.transform.position, Pattern1.transform.rotation);
			Instantiate (Pattern4, Pattern4.transform.position, Pattern4.transform.rotation);
			//Pattern4.gameObject.SetActive (true);

			yield return new WaitForSeconds (WaitingTime4);


			Instantiate (Pattern2, Pattern2.transform.position, Pattern2.transform.rotation);
			Instantiate (Pattern6, Pattern6.transform.position, Pattern6.transform.rotation);

			//Pattern5.gameObject.SetActive (true);

			yield return new WaitForSeconds (WaitingTime5);

			Instantiate (Pattern5, Pattern5.transform.position, Pattern5.transform.rotation);
			//Pattern6.gameObject.SetActive (true);

			yield return new WaitForSeconds (WaitingTime6);
			Instantiate (Pattern7, Pattern7.transform.position, Pattern7.transform.rotation);
			//Pattern7.gameObject.SetActive (true);

			yield return new WaitForSeconds (WaitingTime7);
			Instantiate (Pattern8, Pattern8.transform.position, Pattern8.transform.rotation);
			Instantiate (Pattern1, Pattern8.transform.position, Pattern8.transform.rotation);
			//Pattern8.gameObject.SetActive (true);

			yield return new WaitForSeconds (WaitingTime8);
			Instantiate (Pattern9, Pattern9.transform.position, Pattern9.transform.rotation);
			Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);
			//Pattern9.gameObject.SetActive (true);

			StartCoroutine (BossPatternManager1 (5f));
		}*/

	// Update is called once per frame
    /*
	void Update () {

		if (BossHPPercent <= 0) {
			Instantiate (NextBoss, this.gameObject.transform.position, this.gameObject.transform.rotation);
			Destroy (gameObject, 0.5f);

		}
	}*/
}
