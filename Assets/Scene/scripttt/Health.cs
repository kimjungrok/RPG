
using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	public float Damage;
	GameObject DamageScreen;
	GameObject gameoverScreen;

	//GameObject Player;

	/*
	void OnCollisionEnter(Collision col) {
		//foreach (var contact in col.contacts) {
		if(col.gameObject.tag=="enemy") {
			health -= Damage;
		}

		if (health <= 0) {
			Destroy (gameObject);
		}
	}*/

	void Start ()
	{
		DamageScreen = GameObject.FindGameObjectWithTag ("damagescreen");
		gameoverScreen = GameObject.FindGameObjectWithTag ("gameover");
		//Player = GameObject.FindGameObjectWithTag ("Player");
	}

	IEnumerator damageed(float waitTime){
		yield return new WaitForSeconds (0.3f);
		DamageScreen.transform.position = DamageScreen.transform.position + new Vector3 (0, 3.8f, -2.6f);
	}
	/*
	void DestroyedGameobject(GameObject gameobject)
	{
		Destroy(gameObject);
	}*/

		
	void OnTriggerEnter (Collider Coll)
	{

		if (Coll.gameObject.tag == "enemy") {
			health -= Damage;

			//DamageScreen.SetActive (true);

			DamageScreen.transform.position = DamageScreen.transform.position + new Vector3 (0, -3.8f, 2.6f);
			StartCoroutine(damageed(0.3f));

		}
		if (health <= 0) {
			//gameoverScreen.transform.position = gameoverScreen.transform.position + new Vector3 (0, -14.27f, 9.71f);
			//Invoke("DestroyedGameobject", 0.01f);
			Destroy(gameObject);
		}
	}
}