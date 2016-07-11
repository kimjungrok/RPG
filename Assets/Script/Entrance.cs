using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {

	public int indexMoveStage;
    public Transform transPlayerInNextStage;
    private GameManager gm;
    private Collider doorCollider;
    void Start()
    {
        doorCollider = GetComponent<Collider>();        
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(ColliderDelay());
    }

    void OnTriggerEnter(Collider colOther)
    {
        if (colOther.CompareTag("Player"))
            {
                gm.MoveStage(indexMoveStage, transPlayerInNextStage.position);
           }
                
    }
    public bool isOpen
    {
        get
        {
            return doorCollider.isTrigger;
        }
        set
        {
            doorCollider.isTrigger = value;
        }
    }
    IEnumerator ColliderDelay()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        GetComponent<BoxCollider>().enabled = true;
    }

}
