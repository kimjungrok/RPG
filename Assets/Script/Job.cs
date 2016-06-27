using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Job  {
    // 한 직업에 대한 정보 클래스 

    public enum JOB{ WARRIOR, ARCHER } // 직업 정보

    public JOB job;
    public List<Level> listLevelInfo;   // 레벨별 스탯 정보  
    public List<Skill> listSkill;       // 스킬 정보

    public Level getLevelInfo(int level)
    {
        if (level < 0)
            return null;

        else if (level >= listLevelInfo.Count)
            return null;

        return listLevelInfo[level];
    }
}
