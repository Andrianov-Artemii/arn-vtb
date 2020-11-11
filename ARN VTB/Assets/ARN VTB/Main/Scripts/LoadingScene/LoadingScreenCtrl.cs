using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class LoadingScreenCtrl : MonoBehaviour
{
    [SerializeField] private RectTransform logoImgRect;
    [SerializeField] private RectTransform logoBgRect;
    [SerializeField] private RectTransform welcomeTxt;
    [SerializeField] private RectTransform acceptTxt;
    [SerializeField] private RectTransform submitBtnRect;
    [SerializeField] private Button submitBtn;
    [SerializeField] private float animationDelay = 0.5f;
    [SerializeField] private Ease defaultType;

    void Start()
    {

        Sequence sequence = DOTween.Sequence();
        sequence.SetEase(defaultType);
        sequence.AppendInterval(animationDelay);
        sequence.Append(logoBgRect.DOAnchorPosX(0, animationDelay));
        sequence.Join(logoImgRect.DOAnchorPosX(0, animationDelay));
        sequence.Append(welcomeTxt.DOAnchorPosY(0, animationDelay));
        sequence.Join(welcomeTxt.GetComponent<Text>().DOFade(1, animationDelay));
        sequence.Append(acceptTxt.DOAnchorPosY(0, animationDelay));
        sequence.Join(acceptTxt.GetComponent<Text>().DOFade(1, animationDelay));
        sequence.Append(submitBtnRect.DOAnchorPosY(48, animationDelay));
        sequence.OnComplete(() => submitBtnRect.DOScale(1.03f, animationDelay).SetLoops(-1, LoopType.Yoyo));
    }

}
