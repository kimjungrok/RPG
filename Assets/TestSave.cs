using UnityEngine;
using System.Collections;

public class TestSave : MonoBehaviour {

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.isOpenUISaveLoad())
            {
                GameManager.instance.CloseUISaveLoad();
            }
            else
            {
                GameManager.instance.OpenUISaveLoad(UISaveLoadInfo.MODE.SAVELOAD, null);
            }
        }
    }   
}
