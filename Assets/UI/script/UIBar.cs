using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIBar : MonoBehaviour {

    public UIValueBar HpBar;
    public UIValueBar SpBar;
    public UIValueBar ExpBar;
    public Text txtLevel;
    public Text txtStage;

    public void setTextStage(string str)
    {
        txtStage.text = str;
    }
    public void setLevel(int level)
    {
        txtLevel.text = level.ToString();
    }
    public UIValueBar getHpBar()
    {
        return HpBar;
    }
    public UIValueBar getSpBar()
    {
        return SpBar;
    }
    public UIValueBar getExpBar()
    {
        return ExpBar;
    }    
}
