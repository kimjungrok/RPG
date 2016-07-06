using UnityEngine;
using System.Collections;

public class SceneMainUILogic : MonoBehaviour {
    // 메인 씬의 UI 이벤트를 다룬다.

    public GameObject objUIMain;
    public GameObject objUISaveLoad;
    private UISaveLoadInfo m_uiSaveLoad;
    void Start()
    {
        m_uiSaveLoad = objUISaveLoad.GetComponent<UISaveLoadInfo>();
    }
    public void OnClickExit() // 종료 클릭 시
    {
        GameManager.instance.ExitGame();
    }

    public void OnClickLoadGame() // 불러오기 클릭 시
    {
        objUIMain.SetActive(false); 
        m_uiSaveLoad.OnClose -= OnCloseUISaveLoad;
        m_uiSaveLoad.OnClose += OnCloseUISaveLoad;
        m_uiSaveLoad.Open(UISaveLoadInfo.MODE.LOAD);
    }

    public void OnClickNewGame() // 새 게임 클릭 시
    {
        GameManager.instance.StartNewGame();
    }

    public void OnCloseUISaveLoad()
    {
        objUIMain.SetActive(true);
    }
}
