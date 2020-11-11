using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchItem : MonoBehaviour
{
    public Text t;
    public Image target;
    //public InputField input;

    System.Action<SearchItem> collback;
    [HideInInspector]
    public Search.SearchSer search;
    public void Open(Search.SearchSer s, System.Action<SearchItem> collback)//, InputField i = null)
    {
        this.collback = collback;
        search = s;
        t.text = s.name;
        //input = i;
    }

    public void Select()
    {
        target.enabled = true;
    }

    public void DeSelect()
    {
        target.enabled = false;
    }


    public void Tap()
    {
        collback.Invoke(this);
    }

    //public void ChangeInput()
    //{
    //    Debug.Log("change");
    //    if (input != null)
    //    {
    //        input.text = t.text;
    //    }
    //}


}
