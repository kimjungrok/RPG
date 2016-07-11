using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public enum MODE { ONCE, CONTINUOUS } // 한번만, 계속 생성

    public MODE mode;   
    public GameObject prefabMonster; // 생성할 몬스터
    public float waitTime = 5f;  // 대기시간   
    public GameObject activeEntrance; // 다음방 활성화
    private GameObject objMonster; // 생성된 몬스터

    void Start()
    {
        CreateNewMonster();
    }

    private void CreateNewMonster()
    {
        objMonster = Instantiate(prefabMonster, transform.position, transform.rotation) as GameObject;
        objMonster.GetComponent<MonsterManager>().OnDeath += Respawn;
    }

    public void Respawn()
    {
        objMonster.GetComponent<MonsterManager>().OnDeath -= Respawn;

        if (activeEntrance != null)
        { 
            Entrance enter = activeEntrance.GetComponent<Entrance>();
            enter.isOpen = true;
        }

        if (mode == MODE.CONTINUOUS)
            StartCoroutine(Waiting());
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        CreateNewMonster();
    }
}
