using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonSwitcher : MonoBehaviour
{
    [SerializeField] private Color blueColor;
    [SerializeField] private Color whiteColor;
    [SerializeField] private float animationSpeed = 0.2f;
    public void SetToggleActive(RectTransform panel)
    {
        if (GetComponent<Toggle>().isOn)
        {
            transform.GetChild(0).GetComponent<Image>().DOColor(whiteColor, animationSpeed);
            panel.DOAnchorPosY(-300, animationSpeed);

        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().DOColor(blueColor, animationSpeed);
            panel.DOAnchorPosY(-1200, animationSpeed);
        }
    }
}
