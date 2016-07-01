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

	public GameObject Boss2;


	//public List<GameObject> ListPattern;
	//[Range(0,1)]
	//public float testHP;

	float BossHPPercent;


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
		BossHPPercent = GetComponent<MonsterManager> ().MonsterCurrentHP / GetComponent<MonsterManager> ().MonsterMaxHP;
		StartCoroutine (BossPatternManager1(5f));

	}

	void HPcheak(){
		if (BossHPPercent < 0.7f) {
			
			StopCoroutine (BossPatternManager1 (5f));

			StartCoroutine (BossPatternManager2 (5f));
			enabled = false;
		}
	}

	IEnumerator BossPatternManager1(float RegTime)
	{
		if (BossHPPercent >= 0.7f) { //for문 써서 수정하려면 패턴 담는 공간이 없어짐
			yield return new WaitForSeconds (5);

			/*
			for (int i; i < 11; i++) {
				if (i > 9) {
					i = 1;
				}
			}*/

			Instantiate (Pattern1, Pattern1.transform.position, Pattern1.transform.rotation);

			//Pattern1.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			HPcheak ();

			Instantiate (Pattern2, Pattern2.transform.position, Pattern2.transform.rotation);

			//Pattern2.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			HPcheak ();

			Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);
			//Pattern3.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			HPcheak ();

			Instantiate (Pattern4, Pattern4.transform.position, Pattern4.transform.rotation);
			//Pattern4.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			HPcheak ();

			Instantiate (Pattern5, Pattern5.transform.position, Pattern5.transform.rotation);
			//Pattern5.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			HPcheak ();

			Instantiate (Pattern6, Pattern6.transform.position, Pattern6.transform.rotation);
			//Pattern6.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			HPcheak ();

			Instantiate (Pattern7, Pattern7.transform.position, Pattern7.transform.rotation);
			//Pattern7.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			HPcheak ();

			Instantiate (Pattern8, Pattern8.transform.position, Pattern8.transform.rotation);
			//Pattern8.gameObject.SetActive (true);

			yield return new WaitForSeconds (15);
			HPcheak ();

			Instantiate (Pattern9, Pattern9.transform.position, Pattern9.transform.rotation);
			//Pattern9.gameObject.SetActive (true);

			StartCoroutine (BossPatternManager1 (5f));
		}
			
		/*
		else if ((0.25f < BossHPPercent) && (BossHPPercent < 0.7f)) {
	
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
		}*/
	}

	IEnumerator BossPatternManager2(float RegTime){
		yield return new WaitForSeconds (5);

		Instantiate (Pattern1, Pattern1.transform.position, Pattern1.transform.rotation);
		Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);
		//Pattern1.gameObject.SetActive (true);

		yield return new WaitForSeconds (15);


		Instantiate (Pattern2, Pattern2.transform.position, Pattern2.transform.rotation);
		Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);

		yield return new WaitForSeconds (15);

		Instantiate (Pattern1, Pattern1.transform.position, Pattern1.transform.rotation);
		Instantiate (Pattern4, Pattern4.transform.position, Pattern4.transform.rotation);
		//Pattern4.gameObject.SetActive (true);

		yield return new WaitForSeconds (15);


		Instantiate (Pattern2, Pattern2.transform.position, Pattern2.transform.rotation);
		Instantiate (Pattern6, Pattern6.transform.position, Pattern6.transform.rotation);

		//Pattern5.gameObject.SetActive (true);

		yield return new WaitForSeconds (15);

		Instantiate (Pattern5, Pattern5.transform.position, Pattern5.transform.rotation);
		//Pattern6.gameObject.SetActive (true);

		yield return new WaitForSeconds (15);
		Instantiate (Pattern7, Pattern7.transform.position, Pattern7.transform.rotation);
		//Pattern7.gameObject.SetActive (true);

		yield return new WaitForSeconds (15);
		Instantiate (Pattern8, Pattern8.transform.position, Pattern8.transform.rotation);
		Instantiate (Pattern1, Pattern8.transform.position, Pattern8.transform.rotation);
		//Pattern8.gameObject.SetActive (true);

		yield return new WaitForSeconds (15);
		Instantiate (Pattern9, Pattern9.transform.position, Pattern9.transform.rotation);
		Instantiate (Pattern3, Pattern3.transform.position, Pattern3.transform.rotation);
		//Pattern9.gameObject.SetActive (true);

		StartCoroutine (BossPatternManager2 (5f));
	}

	// Update is called once per frame
	void Update () {
		//HPcheak ();
		if (BossHPPercent <= 0) {
			Instantiate (Boss2, this.gameObject.transform.position, this.gameObject.transform.rotation);
			Destroy (gameObject, 0.5f);

		}
	}
}
