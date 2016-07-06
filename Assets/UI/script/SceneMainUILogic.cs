using UnityEngine;
using System.Collections;

public class SceneMainUILogic : MonoBehaviour {
    // 메인 씬의 UI 이벤트를 다룬다.


	// Use this for initialization
	void Start () {
	
	}

    public void OnClickExit() // 종료 클릭 시
    {
        GameManager.instance.ExitGame();
    }

    public void OnClickLoadGame() // 불러오기 클릭 시
    {
    }

    public void OnClickNewGame() // 새 게임 클릭 시
    {
        GameManager.instance.StartNewGame();
    }
}
