using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Job  {
    // 한 직업에 대한 정보 클래스 

    public enum JOB{ WARRIOR, ARCHER } // 직업 정보

    public JOB job;
    public string jobName;                  // 직업 이름
    public GameObject jopPrefab;            // 직업 프리팹
    public List<Skill> listSkill;           // 스킬 정보

    public int maxLevel = 20;               // 최대 레벨

    public int BaserequiredExp = 100;       // 초기 필요경험치
    public float ExpRateofIncrease = 1.1f;  // 레벨별 필요경험치 증가율 (초기값 110%)

    public int BaseHp = 100;                // 기본 HP Max
    public int AddHp = 5;                   // 레벨별 추가 HP Max

    public int BaseSp = 100;                // 기본 SP Max
    public int AddSp = 5;                   // 레벨별 추가 SP Max

    public int BaseAp = 10;                 // 기본 공격력
    public int AddAp = 5;                   // 레벨별 추가 AP 

    public int BaseHpRegen = 1;             // 기본 HP 리젠
    public float BaseHpRegenInteval = 1f;   // HP 리젠 간격

    public int BaseSpRegen = 1;             // 기본 SP 리젠 
    public float BaseSpRegenInteval = 1f;   // SP 리젠 간격

    public Stat getStatInfo(int level)
    {
        if (level <= 0) // 최소렙 1
            level = 1;

        else if (level > maxLevel) // 최대 렙
            level = maxLevel;

        Stat stat = new Stat();
        stat.requiredExp = (int)(BaserequiredExp * Mathf.Pow(ExpRateofIncrease, (level - 1))); // ex> 100 * 1.1^2
        stat.maxHP = BaseHp + AddHp * level;    // 맥스 Hp
        stat.maxSP = BaseSp + AddSp * level;    // 맥스 Sp
        stat.attackPower = BaseAp + AddAp * level;
        stat.hpRegenerate = BaseHpRegen;
        stat.spRegenerate = BaseSpRegen;

        return stat; 
    }

    public Skill getSkill(int level) // 레벨에 해당하는 스킬을 얻는다.
    {
        if(listSkill.Count == 0)
            return null;

        Skill skillResult = listSkill[0];

        for(int i = 1; i < listSkill.Count; i++)
        {
            Skill skill = listSkill[i];
            if (skill.enableLv <= level)
            {
                skillResult = skill;
            }
            else
                break;
        }
        return skillResult;
    }
}
