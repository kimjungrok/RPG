using UnityEngine;
using System.Collections;

public class WeaponCollider : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Monster")) // 몬스터 타격시
        {
            transform.root.GetComponent<Player>().Hit(col.transform.root.GetComponent<MonsterManager>());            
        }
    }	
}
