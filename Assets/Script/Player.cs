using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public enum STATE { IDLE, DEATH }     

    // 속성
    public STATE state; // 현재 상태를 얻습니다. get

    // 메서드
    public bool Damaged(int damage) // 데미지를 받는다. 성공 여부를 되돌려준다. Stat 클래스 - Hp정보 필요
    {
        return false;
    }
    public bool Cast(int indexSkill) // 스킬을 시전합니다. 성공 여부를 되돌려 줍니다.
    {
        return false; 
    }
}
