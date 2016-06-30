using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Job  {
    // 한 직업에 대한 정보 클래스 

    public enum JOB{ WARRIOR, ARCHER } // 직업 정보

    public JOB job;
    public GameObject jopPrefab;       // 직업 프리팹
    public List<Stat> listStatInfo;   // 레벨별 스탯 정보  
    public List<Skill> listSkill;       // 스킬 정보

    public Stat getStatInfo(int level)
    {
        if (level <= 0) // 최소렙 1
            level = 1;

        else if (level > listStatInfo.Count) // 최대 렙
            level = listStatInfo.Count;

        // 인덱스 = 레벨 - 1 // 인덱스는 0부터 시작, 레벨은 1부터 시작.
        return listStatInfo[level-1]; 
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
