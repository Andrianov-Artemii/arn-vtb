using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSpechialElement : MonoBehaviour
{
    public SearchResultController sec;
    public GameObject menPanel;
    public string elName;


    private void Start()
    {
        sec = GetComponent<SearchResultController>();
        sec.OnTapAction += TogglePanel;
    }

    private void TogglePanel(SearchItem s)
    {
        menPanel.SetActive(s.t.text == elName);
    }



   


}
