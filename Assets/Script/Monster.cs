using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	public int monsterHP = 100;

	void Update(){

	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.tag == "Weapon") {
			monsterHP -= 50;

		}
		if(monsterHP == 0){
				Destroy (gameObject);
		}	
	}
}

