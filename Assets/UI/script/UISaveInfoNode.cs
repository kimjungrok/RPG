using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISaveInfoNode : MonoBehaviour {

    public Text txtInfo; // 정보 출력 텍스트
    private Button btnNode;
    private SaveInfo saveInfo;
    public delegate void OnClickEvent(GameObject obj, SaveInfo info);
    public event OnClickEvent OnClick;

    
    void Awake()
    {
        btnNode = GetComponent<Button>();
    }

    void Start()
    {
        btnNode.onClick.AddListener(() => OnClickNode());
    }

    public void setSaveInfo(SaveInfo saveInfo) // 출력 정보
    {
        this.saveInfo = saveInfo;
        string total = GameManager.instance.getJobInfo(saveInfo.job).jobName;

        // 직업 level 스테이지 날짜 시간
        total += " Lv." + saveInfo.level;
        total += " " + GameManager.instance.listStage[saveInfo.stageNumber].stageName;
        total += " " + saveInfo.date;
        total += " " + saveInfo.time;

        txtInfo.text = total;
    }
    public void OnClickNode() // 저장된 정보 클릭
    {
        OnClick(gameObject, saveInfo);
    }
}
