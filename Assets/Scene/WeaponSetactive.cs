using UnityEngine;
using System.Collections;

public class WeaponSetactive : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

/*
	IEnumerator WeaponDisable(float DisableTime){
		yield return new WaitForSeconds (0.05f);
		this.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.gameObject == player) {
			
			this.gameObject.SetActive (true);
			WeaponDisable (0.05f);

		}
	}
	
	// Update is called once per frame
	void Update () {

		col.enabled = false;
	
	}
*/

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player")) // 플레이어 타격시
        {
            transform.root.GetComponent<MonsterManager>().HitforPlayer(col.transform.root.GetComponent<Player>());
        }
    }
}
