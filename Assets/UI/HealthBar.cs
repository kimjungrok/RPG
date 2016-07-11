using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {

    public RectTransform rectFillParent;
    public RectTransform rectSubFillParent;
    public Text textHP;
    public float ChangeSpeed = 1f;
    public bool bAnimation = true;
    int maxHP = 100;
    int curHP = 100;
    int subHP = 100;
    float fHPPercent;
    float originPosX;
    Coroutine corAnimationHPBar;

    void Start()
    {
        originPosX = rectFillParent.anchoredPosition.x;
    }
    public void SetupHP(int maxHP, int curHP)
    {
        
        this.maxHP = maxHP;
        this.curHP = curHP;
        this.subHP = curHP;
        fHPPercent = (float)curHP / (float)maxHP;
        SetHPText();
    }
    public void SetHPText()
    {
        textHP.text = curHP.ToString();
        textHP.text = curHP.ToString() + " / " + maxHP.ToString() + "  ( " + string.Format("{0:P0}", fHPPercent) + " ) ";
    }
    public void changeHP(int HP)
    {
        if (HP == curHP)
            return;
       
        int preHP = curHP;
        curHP = HP;
        fHPPercent = (float)curHP / (float)maxHP;
        SetHPText();
        
        float moveDistance = rectFillParent.rect.width * (1f - fHPPercent);
        if (corAnimationHPBar != null)
        {
            StopCoroutine(corAnimationHPBar);
        }
      
        Vector3 vecNewPos = rectFillParent.anchoredPosition;
        vecNewPos.x = originPosX -moveDistance;
        if (bAnimation)
        {
            if (HP < preHP) // 감소 애니메이션
            {
                rectFillParent.anchoredPosition = vecNewPos;
                corAnimationHPBar = StartCoroutine(AnimationHPBar(rectSubFillParent, rectFillParent));
            }
            else // 증가 애니메이션
            {
                rectSubFillParent.anchoredPosition = vecNewPos;
                corAnimationHPBar = StartCoroutine(AnimationHPBar(rectFillParent, rectSubFillParent));
            }
        }
        else
        {
            rectFillParent.anchoredPosition = vecNewPos;
            rectSubFillParent.anchoredPosition = vecNewPos;
        }
    }
    
    IEnumerator AnimationHPBar(RectTransform rectMove, RectTransform rectTarget)
    {        
        Vector2 vecStartPos = rectMove.anchoredPosition;
        float percent = 0f;
        while (rectMove.anchoredPosition.x != rectTarget.anchoredPosition.x)
        {
            rectMove.anchoredPosition = Vector2.Lerp(vecStartPos, rectTarget.anchoredPosition, percent);
            yield return new WaitForFixedUpdate();
            percent += Time.deltaTime * ChangeSpeed;
        }
    }
}
