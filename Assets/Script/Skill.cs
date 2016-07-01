using UnityEngine;
using System.Collections;

[System.Serializable]
public class Skill {

    // 플레이어의 스킬 클래스    
    public string skillName;    // 스킬 이름
    public int damage;          // percent 단위
    public GameObject effect;   // 스킬 effect
    public float range;         // 범위   
    public int enableLv;        // 해제 레벨(사용가능한 레벨)
}
