using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneMainUILogic : MonoBehaviour {
    // 메인 씬의 UI 이벤트를 다룬다.

    public GameObject objUIMain;
    public void OnClickExit() // 종료 클릭 시
    {
        GameManager.instance.ExitGame();
    }

    public void OnClickLoadGame() // 불러오기 클릭 시
    {
        objUIMain.SetActive(false); 
        /*
        m_uiSaveLoad.OnClose += OnCloseUISaveLoad;
        m_uiSaveLoad.Open(UISaveLoadInfo.MODE.LOAD);
        */

        GameManager.instance.OpenUISaveLoad(UISaveLoadInfo.MODE.LOAD, OnCloseUISaveLoad);
            

        /*
        List<SaveInfo> listSaveInfo = GameManager.instance.getAllSaveInfo();
        if (listSaveInfo.Count != 0)
        {
            Debug.Log(listSaveInfo.Count);
            GameManager.instance.LoadGame(listSaveInfo[0]);
        }*/

    }

    public void OnClickNewGame() // 새 게임 클릭 시
    {        
        GameManager.instance.StartNewGame(0, null);
    }

    public void OnCloseUISaveLoad()
    {
        objUIMain.SetActive(true);
    }
}
