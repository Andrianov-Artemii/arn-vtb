using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private Button locationInfoBtn;
    [SerializeField] private RectTransform locationPanel;
    [SerializeField] private Button stickerBtn;
    [SerializeField] private RectTransform stickerPanel;

    private void OnEnable()
    {
        locationInfoBtn.onClick.AddListener(()=>ShowInfoPanel(750f, locationPanel));
        stickerBtn.onClick.AddListener(() => ShowInfoPanel(650, stickerPanel));
    }

    private void OnDisable()
    {
        locationInfoBtn.onClick.RemoveAllListeners();
        stickerBtn.onClick.RemoveAllListeners();
    }
    public void ShowInfoPanel(float downPadding, RectTransform currentPanel)
    {
        currentPanel.gameObject.SetActive(true);
        currentPanel.DOAnchorPosY(downPadding, 0.5f).SetEase(Ease.OutBack);
    }

    public void HideInfoPanel(RectTransform currentPanel)
    {
        currentPanel.DOAnchorPosY(0, 0.5f).SetEase(Ease.OutBack).OnComplete(() => currentPanel.gameObject.SetActive(false));
    }
}
