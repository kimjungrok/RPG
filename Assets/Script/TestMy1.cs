using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TestMy1 : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	void Start()
    {
        Debug.Log("Start Teset");
        SceneManager.LoadScene("SceneGame");
    }
}
