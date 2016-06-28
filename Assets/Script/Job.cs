using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Job  {
    // 한 직업에 대한 정보 클래스 

    public enum JOB{ WARRIOR, ARCHER } // 직업 정보

    public JOB job;
    public List<Stat> listStatInfo;   // 레벨별 스탯 정보  
    public List<Skill> listSkill;       // 스킬 정보
    
    public Stat getStatInfo(int level)
    {
        if (level < 0)
            return null;

        else if (level >= listStatInfo.Count)
            return null;

        return listStatInfo[level];
    }
}
