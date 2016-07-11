using UnityEngine;
using System.Collections;

public class MoveSmoke : MonoBehaviour
{

    public float Smoke;
    private float startTime;

    void Start()
    {

        startTime = Time.time;
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(Smoke);
        Destroy(gameObject);
    }


}
