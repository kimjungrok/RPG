using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {

	public int indexMoveStage;
    public Transform transPlayerInNextStage;
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider colOther)
    {
        if (colOther.CompareTag("Player"))
        {
            StartCoroutine(moveStage());
        }
    }

    IEnumerator moveStage()
    {
        gm.MoveStage(indexMoveStage);
        gm.getObjPlayer().transform.position = transPlayerInNextStage.position;
        yield return new WaitForSeconds(0f);
        
    }
}
