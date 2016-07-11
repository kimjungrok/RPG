using UnityEngine;
using System.Collections;

public class WeaponSetactive : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player")) // 플레이어 타격시
        {
            transform.root.GetComponent<MonsterManager>().HitforPlayer(col.transform.root.GetComponent<Player>());
        }
    }
}
