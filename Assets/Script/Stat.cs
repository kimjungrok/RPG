using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stat : MonoBehaviour {

    public Job.JOB job; 

    private int m_Hp;                 // 현재 HP
    private int m_HpMaxBuff;          // Buff HP (장비로 인한 추가 HP)
    private int m_HpRegenerateBuff;   // 분당 회복력 버프

    private int m_Sp;                 // spellPower, 현재 SP
    private int m_SpMaxIncrease;      // Buff sp (장비로 인한 추가 sp)
    private int m_SpRegenerateBuff;   // 분당 회복력 버프

    private int m_AttackPowerBuff;    // 공격력 버프

    private int m_Level = 1;          // 현재 레벨 , 기본값 1
    private int m_Experience;         // 현재 경험치

    private Job m_Job;                // 현재 직업 정보(스킬, 레벨별 스탯)

    // 프로퍼티(속성)
    public int hp // 현재 Hp를 제어.  get,set
    {
        get
        {
            return m_Hp;
        }
        set
        {
            m_Hp = value;
        }
    }

    public int HpMax // Max HP를 얻는다 (기본 MaxHP + Buff MaxHP ) getp   
    {
        get
        {
            return m_Hp + m_HpMaxBuff;
        }
        set
        {
            HpMax = value;
        }
    }
    public int HpMaxBuff // 아이템으로 인한 Max Hp 증가량 제어 get, set
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
    public int HpRegenerate; // HP 분당 회복량을 얻는다. (기본 + 버프) get        
    public int HpRegenerateBuff; // 아이템으로 인한 HP 분당 회복량을 제어 get, set

    public int Sp; // 현재 Sp를 제어 get,set
    public int SpMax; // 현재 Max SP를 얻는다.( 기본 Max SP + Buff Max SP) get
    public int SpMaxBuff; // 아이템으로 인한 Max Sp 증가량 제어 get, set
    public int SpRegenerate; // SP 분당 회복량을 얻는다. get
    public int SpRegenerateBuff; // 아이템으로 인한 SP 분당 회복량 제어 get, set

    public int AttackPower;      // 전체 공격력을 얻는다 (기본 + 버프) get
    public int BaseAttackPower;  // 기본 공격력을 얻는다. get
    public int AttackPowerBuff;  // 공격력 버프량(아이템으로 인한)을 제어 get, set

    public int Lv; //현재 레벨을 제어. get, set
    public int Exp; // 현재 경험치 제어. get, set
    
    void Start()
    {
        m_Job = GameObject.Find("Logic").GetComponent<JobInfo>().getJobInfo(job);
    }

    private Level getLevelInfo()
    {
        return m_Job.getLevelInfo(m_Level);
    }
}
