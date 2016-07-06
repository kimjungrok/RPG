using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UISaveLoadInfo : MonoBehaviour {

    public enum MODE { LOAD, SAVELOAD } // 저장, 저장/불러오기 모드
    public delegate void OnCloseEvent(); // 닫기 이벤트
    public event OnCloseEvent OnClose;

    public GameObject objScrollParent;     // 스크롤뷰 내용들의 부모
    public GameObject objNode;
    public Text txtCurrentPlayerInfo;   // 현재 플레이어 정보
    public Text txtSaveInfo;            // 클릭한 저장 정보
    public Button btnNewSave;           // 새로저장 버튼
    public Button btnLoad;              // 로드 버튼
    public Button btnRemove;            // 삭제 버튼
    public GameObject objPopupNewSave;         // 새 저장 팝업
    public InputField inputNewSaveName;              // 새저장 이름 텍스트
    private SaveInfo curSaveInfo;           // 현재 정보
    private List<GameObject> listBtnSaveInfo = new List<GameObject>();      // 저장 정보 버튼들
    private List<SaveInfo> listSaveInfo = new List<SaveInfo>();             // 저장 정보 들
    private bool bNewSavePopupOpened = false;
    private MODE mode;

    private void Init()
    {
        // UI 초기화
        txtCurrentPlayerInfo.text = "";
        txtSaveInfo.text = "";
        btnLoad.gameObject.SetActive(false);
        btnRemove.gameObject.SetActive(false);
        PopupClose();

        // 스크롤 초기화
        foreach (GameObject objBtn in listBtnSaveInfo)
        {
            Destroy(objBtn);
        }            

        listBtnSaveInfo.Clear();
        listSaveInfo.Clear();

        // 모든 저장정보 불러오기
        listSaveInfo = GameManager.instance.getAllSaveInfo();

        if(mode == MODE.SAVELOAD)
        {
            // 현재 정보 얻기
            curSaveInfo = GameManager.instance.getSaveInfo();

            // 텍스트 정보로 가공하기
        }

        // 저장정보 갯수만큼 스크롤뷰에 버튼 채우기
        foreach ( SaveInfo info in listSaveInfo)
        {
            GameObject objNewNode = Instantiate(objNode);
            objNewNode.transform.parent = objScrollParent.transform;
            UISaveInfoNode uiNode = objNewNode.GetComponent<UISaveInfoNode>();
            uiNode.setSaveInfo(info);
            uiNode.OnClick += OnClickSaveInfoNode;
            listBtnSaveInfo.Add(objNewNode);
        }

    }

    public void Open(MODE mode)
    {
        this.mode = mode;
        Init();
        if (mode == MODE.SAVELOAD) // 저장/불러오기 동시
        {
            btnNewSave.gameObject.SetActive(true); // 새 저장 버튼 보이기
        }
        else // 불러오기만
        {
            btnNewSave.gameObject.SetActive(false); // 새 저장 버튼 감추기
        }
        gameObject.SetActive(true);        
    }

    public void Close()
    {
        gameObject.SetActive(false);
        OnClose();
    }

    public void OnClickNewSave() // 새로 저장 클릭
    {
        PopupOpen();
    }

    public void OnClickRemoveSaveInfo() // 삭제 클릭
    {
        
    }

    public void OnClickLoadSaveInfo() // 불러오기 클릭
    {

    }

    public void OnClickSaveInfoNode(GameObject obj, SaveInfo info) // 저장 정보 클릭 시
    {

    }

    public void OnClickPopupOK() // 팝업 - 저장 
    {
        Debug.Log(inputNewSaveName.text);
        PopupClose();
    }

    public void PopupOpen()
    {
        inputNewSaveName.text = "";
        objPopupNewSave.SetActive(true);
    }

    public void PopupClose()
    {
        objPopupNewSave.SetActive(false);
    }
}
