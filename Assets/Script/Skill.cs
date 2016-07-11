using UnityEngine;
using System.Collections;

[System.Serializable]
public class Skill {

    // 플레이어의 스킬 클래스    
    public string skillName;    // 스킬 이름
    public string skillAnimationName; // 스킬애니메이션이름
    public float damageScale;          // 스킬공격력 = damageScale * 케릭터 공격력 
    public int requiredSp;          // 필요 SP
    public GameObject effect;   // 스킬 effect
    public int enableLv;        // 해제 레벨(사용가능한 레벨)

    public int getSkillDamage(int attackPower)
    {
        return (int)((float)attackPower * damageScale);
    }
}
