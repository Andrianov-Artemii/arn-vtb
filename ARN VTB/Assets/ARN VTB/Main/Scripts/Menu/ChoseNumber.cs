using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseNumber : MonoBehaviour
{
    public Button nextButton;
    public Color inactiveNextColor;
    public Sprite inactiveNextIcon;
    public Color activeNextColor;
    public Sprite activeNextIcon;

    public InputField input;
    public SearchResultController sres;
    public int maxValue = 26;
    public int minValue = 1;
    public string currCabinet = "";


    private void Start()
    {
        //sres.gameObject.SetActive(true);
        //sres.input = input;
        //sres.gameObject.SetActive(false);
        input.onValueChanged.AddListener((e) => { CheckValue(e); });
        nextButton.onClick.AddListener(() => { sres.gameObject.SetActive(false); });
    }

    public void OnEnable()
    {
        ChooseInput();
    }


    public void ChooseInput()
    {
        sres.input = input;
    }

    private void CheckValue(string e)
    {
        //if (MenuData.mode != 2)
        //{
        //    int value;
        //    bool suc = int.TryParse(e.ToString(), out value);
        //    if (suc && value <= maxValue && value >= minValue)
        //    {
        //        nextButton.interactable = true;
        //        nextButton.GetComponentInChildren<Text>().color = activeNextColor;
        //        nextButton.transform.GetChild(1).GetComponent<Image>().sprite = activeNextIcon;
        //        currCabinet = value;
        //        MenuData.point = currCabinet;
        //    }
        //    else
        //    {
        //        nextButton.interactable = false;
        //        nextButton.GetComponentInChildren<Text>().color = inactiveNextColor;
        //        nextButton.transform.GetChild(1).GetComponent<Image>().sprite = inactiveNextIcon;
        //    }
        //}
        //else

        {
            currCabinet = e;
            nextButton.interactable = true;
            MenuData.point = currCabinet;
            nextButton.GetComponentInChildren<Text>().color = activeNextColor;
            nextButton.transform.GetChild(1).GetComponent<Image>().sprite = activeNextIcon;
        }
    
    }


    public void ChooseThisValue(string s)
    {
        MenuData.point = s;
    }
}
