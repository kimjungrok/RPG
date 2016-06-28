using UnityEngine;
using System.Collections;

[System.Serializable]
public class Stage  {

    //하나의 스테이지는 일반존 + 보스존으로 구성된다.
    public string normalStage; // 일반몹 구간, scene Name;
    public string bossStage;  // 보스존 , Scene Name;
}
