using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveInfo {

    [System.Serializable]
    public struct PlayerItemInfo
    {
        // 인벤토리 아이템 정보
    } 

    public string saveName;     // 저장 이름
    
    public int curHP;           // HP
    public int curSP;           // SP
    public int curExp;          // 현재 경험치
    public int level;           // 레벨
    public Job.JOB job;         // 직업
    public int stageNumber;     // 저장한 스테이지 번호
    public Vector3 pos;         // 위치
    public string date;         // 날짜 // System.DateTime.Now.ToString("yyyy/MM/dd");
    public string time;         // 시간 // System.DateTime.Now.ToString("hh:mm:ss"); 

    public List<PlayerItemInfo> listPlayerItemInfo; // 인벤토리 아이템 정보
}
