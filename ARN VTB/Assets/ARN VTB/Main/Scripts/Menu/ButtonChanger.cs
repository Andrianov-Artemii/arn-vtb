using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChanger : MonoBehaviour
{

    public Button[] selectableButtons;
    public Color inactiveSelectableColor;
    public Color activeSelectableColor;

    public Button nextButton;
    public Color activeNextColor;
    public Sprite activeNextIcon;


    public GameObject[] menuePages;
    public GameObject thisMenuePages;



    int activeButtonNumber = -1;

    void Start()
    {
        for(int i=0; i<selectableButtons.Length; i++)
        {
            var c = i;
            selectableButtons[i].onClick.AddListener(() => { Change(c); });
        }

        nextButton.onClick.AddListener(() => { ChoseNextPage(); });
    }

    public void ChoseNextPage()
    {
        MenuData.mode = activeButtonNumber;
        PersoneMode.current = (PersoneModeType)MenuData.mode;

        thisMenuePages.SetActive(false);
        menuePages[activeButtonNumber].SetActive(true);
    }

    private void Change(int i)
    {
      if (activeButtonNumber != -1)
      {
            selectableButtons[activeButtonNumber].GetComponentInChildren<Text>().color = inactiveSelectableColor;
            selectableButtons[activeButtonNumber].transform.GetChild(1).gameObject.SetActive(false);
      }
        activeButtonNumber = i;
        selectableButtons[activeButtonNumber].GetComponentInChildren<Text>().color = activeSelectableColor;
        selectableButtons[activeButtonNumber].transform.GetChild(1).gameObject.SetActive(true);
        ActivateNextButton();
    }

    private void ActivateNextButton()
    {
        nextButton.interactable = true;
        nextButton.GetComponentInChildren<Text>().color = activeNextColor;
        nextButton.transform.GetChild(1).GetComponent<Image>().sprite = activeNextIcon;
    }
}
