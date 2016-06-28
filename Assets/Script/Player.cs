using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public enum STATE { IDLE, DEATH } // 평소, 죽음

    public STATE state; // 현재 상태를 얻습니다. get
    public Job.JOB job;

    private int m_Hp;                 // 현재 HP
    private int m_HpMaxBuff;          // Buff HP (장비로 인한 추가 HP)
    private int m_HpRegenerateBuff;   // 분당 회복력 버프

    private int m_Sp;                 // spellPower, 현재 SP
    private int m_SpMaxBuff;      // Buff sp (장비로 인한 추가 sp)
    private int m_SpRegenerateBuff;   // 분당 회복력 버프

    private int m_AttackPowerBuff;    // 공격력 버프

    private int m_Level = 1;          // 현재 레벨 , 기본값 1
    private int m_Experience;         // 현재 경험치

    private Job m_Job;                // 현재 직업 정보(스킬, 레벨별 스탯)
    private Skill curSkill;             // 현재 사용 가능한 메인스킬

    // 프로퍼티(속성)
    public int hp // 현재 Hp를 제어.  get,set
    {
        get
        {
            return m_Hp;
        }
        set
        {
            if (value < 0)
                value = 0;
            else if (value > hpMax)
                value = hpMax;

            m_Hp = value;
        }
    }

    public int hpMax // Max HP를 얻는다 (기본 MaxHP + Buff MaxHP ) get   
    {
        get
        {
            return getLevelInfo().maxHP + hpMaxBuff;
        }
    }

    public int hpMaxBuff // 아이템으로 인한 Max Hp 증가량 제어 get, set
    {
        get
        {
            return m_HpMaxBuff;
        }
        set
        {
            m_HpMaxBuff = value;
        }
    }

    public int hpRegenerate // HP 분당 회복량을 얻는다. (기본 + 버프) get        
    {
        get
        {
            return getLevelInfo().hpRegenerate + m_HpRegenerateBuff;
        }
    }
    
    public int hpRegenerateBuff  // 아이템으로 인한 HP 분당 회복량을 제어 get, set
    {
        get
        {
            return m_HpRegenerateBuff;
        }
        set
        {
            m_HpRegenerateBuff = value;
        }
    }

    public int Sp // 현재 Sp를 제어 get,set
    {
        get
        {
            return m_Sp;
        }
        set
        {
            if (value < 0)
                value = 0;
            else if (value > spMax)
                value = spMax;

            m_Sp = value;
        }
    }

    public int spMax // 현재 Max SP를 얻는다.( 기본 Max SP + Buff Max SP) get
    {
        get
        {
            return getLevelInfo().maxSP + spMaxBuff;
        }
    }

    public int spMaxBuff // 아이템으로 인한 Max Sp 증가량 제어 get, set
    {
        get
        {
            return m_SpMaxBuff;
        }
        set
        {
            m_SpMaxBuff = value;
        }
    }

    public int spRegenerate // SP 분당 회복량을 얻는다. get
    {
        get
        {
            return getLevelInfo().spRegenerate + m_SpRegenerateBuff;
        }
    }

    public int spRegenerateBuff // 아이템으로 인한 SP 분당 회복량 제어 get, set
    {
        get
        {
            return m_SpRegenerateBuff;
        }
        set
        {
            m_SpRegenerateBuff = value;
        }
    }

    public int attackPower      // 전체 공격력을 얻는다 (기본 + 버프) get
    {
        get
        {
            return getLevelInfo().attackPower + m_AttackPowerBuff;
        }
    }
    public int baseAttackPower  // 기본 공격력을 얻는다. get
    {
        get
        {
            return getLevelInfo().attackPower;
        }
    }
    public int attackPowerBuff  // 공격력 버프량(아이템으로 인한)을 제어 get, set
    {
        get
        {
            return m_AttackPowerBuff;
        }

        set
        {
            m_AttackPowerBuff = value;
        }
    }

    public int lv //현재 레벨을 제어. get, set
    {
        get
        {
            return m_Level;
        }
        set
        {
            m_Level = value;
        }
    }
    public int exp // 현재 경험치 제어. get, set
    {
        get
        {
            return m_Experience;
        }
        set
        {
            m_Experience = value;
        }
    }

    void Start()
    {
        m_Job = GameObject.Find("Logic").GetComponent<JobInfo>().getJobInfo(job);
    }

    private Level getLevelInfo()
    {
        return m_Job.getLevelInfo(m_Level);
    }

   

    // 메서드
    public bool Damaged(int damage) // 데미지를 받는다. 성공 여부를 되돌려준다. 
    {
        // 상태 확인 

        //      A. 일반 B. 죽음

        
        return false;
    }
    public bool Cast() // 스킬을 시전합니다. 성공 여부를 되돌려 줍니다.
    {
        // 상태 확인
        
        // 스킬 시전

        return false; 
    }
    public void LevelUp()
    {
        // 레벨업

        // Hp, Sp Max

        // 필요 경험치 재 설정

        // 레벨에 따른 메인스킬 변경
    }
    public void DoDeath()
    {
        // 상태 변경 - 죽음
        
    }

    private void setCurrentMainSkill()
    {
        // 현재 레벨을 확인하고 그에 맞는 메인스킬을 설정

    }

}
