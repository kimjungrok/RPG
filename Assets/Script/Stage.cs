using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Stage  {

    public enum TYPE { NORMAL, BOSS }

    public TYPE type;
    public string stageName;                // 스테이지 이름. ex> 용의계곡
    public string sceneName;                // 해당 Scene 이름
    public Transform transDefaultStartingPos;
}
