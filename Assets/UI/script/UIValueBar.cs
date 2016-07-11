using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIValueBar : MonoBehaviour
{
    public RectTransform rectFillParent;
    public Text txtValueInfo;
    int maxValue = 100;
    int curValue = 100;
    float fValuePercent;
    float originPosX;

    void Awake()
    {
        originPosX = rectFillParent.anchoredPosition.x;
    }
    public void SetupValue(int curValue, int maxValue)
    {
        this.maxValue = maxValue;
        this.curValue = curValue;
        fValuePercent = (float)curValue / (float)maxValue;
        setTextValueInfo();
        float moveDistance = rectFillParent.rect.width * (1f - fValuePercent);
        Vector3 vecNewPos = rectFillParent.anchoredPosition;
        vecNewPos.x = originPosX - moveDistance;
        rectFillParent.anchoredPosition = vecNewPos;
    }
    private void setTextValueInfo()
    {
        txtValueInfo.text = curValue.ToString();
        txtValueInfo.text = curValue.ToString() + " / " + maxValue.ToString() + "  ( " + string.Format("{0:P0}", fValuePercent) + " ) ";
    }
}