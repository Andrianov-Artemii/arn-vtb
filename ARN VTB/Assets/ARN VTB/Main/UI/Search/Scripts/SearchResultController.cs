using Mopsicus.Plugins;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SearchResultController : MonoBehaviour
{

    [Space]
    public Vector3 multiplyScale = Vector3.one;
    [Space]

    public Search.DataScriptable dataCab;
    public Search.DataScriptable dataMen;

    public int maxLine = 4;
    public bool showAllWhenEmptyString;
    [Space]
    public GameObject linePref;
    public GameObject sepPref;
    public Transform content;

    [Space]
    public InputField input;


    public event Action<SearchItem> OnTapAction; 




    Search.DataScriptable data
    {
        get
        {
            switch (PersoneMode.current)
            {
                case PersoneModeType.fiz:
                    return dataCab;
                case PersoneModeType.vip:
                    return dataMen;
                default:
                    return dataCab;
            }
        }
    }


    private void OnEnable()
    {
        OpenEmpty();
        FindObjectOfType<LoadSceneController>().OnScene2Load += OpenEmpty;
    }


    private void OnDisable()
    {
        //FindObjectOfType<LoadSceneController>().OnScene2Load -= OpenEmpty;
    }

    private void OpenEmpty()
    {
        Open("");
    }

    public List<GameObject> childs = new List<GameObject>();
    public void Open(string str)
    {
        foreach (var item in childs)
        {
            Destroy(item);
        }
        childs.Clear();

        str = str.ToLower();
        List<Search.SearchSer> list = string.IsNullOrWhiteSpace(str) ?
            data.data :
            data.data.Where(item => item.name.ToLower().Contains(str)).ToList();



        if ((showAllWhenEmptyString || !string.IsNullOrWhiteSpace(str)) && list.Count != 0)
        {
            list = list.OrderBy(item => item.sortingOrder).
            ThenBy(item => item.name.ToLower().IndexOf(str)).
            ThenBy(item => item.name).ToList();


            for (int i = 0; i < list.Count - 1; i++)
            {
                Create(list[i]);
                childs.Add(Instantiate(sepPref, content));
            }
            Create(list.Last());
        }

        GetComponent<RectTransform>().sizeDelta =
            new Vector2(GetComponent<RectTransform>().sizeDelta.x, (!showAllWhenEmptyString && string.IsNullOrWhiteSpace(str) ? 0 : 1) * (10 +
                sepPref.GetComponent<RectTransform>().sizeDelta.y * (Mathf.Min(maxLine, list.Count) - 1) +
                linePref.GetComponent<RectTransform>().sizeDelta.y * Mathf.Min(maxLine, list.Count)));

        GetComponentInChildren<UnityEngine.UI.ScrollRect>().movementType = (list.Count > maxLine) ?
            UnityEngine.UI.ScrollRect.MovementType.Elastic : UnityEngine.UI.ScrollRect.MovementType.Clamped;
    }

    void Create(Search.SearchSer searchSer)
    {
        GameObject go = Instantiate(linePref, content);
        go.GetComponent<SearchItem>().Open(searchSer, OnTap);
        if (searchSer.Equals(lastSearchSer))
        {
            go.GetComponent<SearchItem>().Select();
            last = go.GetComponent<SearchItem>();
        }
        childs.Add(go);
    }


    SearchItem last;
    Search.SearchSer lastSearchSer;

    public void OnTap(SearchItem s)
    {

        var sic = GetComponentInParent<SearchInputController>();

        if (sic != null)
        {

            if (last)
            {
                last.DeSelect();
            }

            lastSearchSer = new Search.SearchSer(s.search);
            last = s;
            s.Select();

            sic.ChangeState();

            MainUIController.mainUIController.SetTarget(new Vector3(
                s.search.pos.x * multiplyScale.x,
                s.search.pos.y * multiplyScale.y,
                s.search.pos.z * multiplyScale.z));
            //Debug.LogError("Костыль заюзан");
        }

        if (input != null)
        {
            input.text = s.t.text;
            input.GetComponent<MobileInputField>().Text = s.t.text;
            gameObject.SetActive(false);

        }

        OnTapAction?.Invoke(s);


    }

    public void SetFirstName()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(SetName(0));
    }

    IEnumerator SetName(float time)
    {
        yield return new WaitForSeconds(time);
        //InSearch(out string res);
        string text = childs[0].GetComponentInChildren<Text>().text;
        input.text = text;
        input.GetComponent<MobileInputField>().Text = text;

        //if (res == "") res = data.data[0].name;
        //Debug.Log(data.data[0].name);
        //input.text = res;
        gameObject.SetActive(false);
    }

    //private bool IsReady()
    //{
    //    var c = data.data.Where(item => item.name.Equals(input.text)).ToList();
    //    return c.Count > 0;
    //}

    bool InSearch(out string res)
    {

        var c = string.IsNullOrWhiteSpace(input.text) ?
            data.data :
            data.data.Where(item => item.name.ToLower().Contains(input.text)).ToList();
        res = "";
        if (c.Count > 0)
        {
            c = c.OrderBy(item => item.sortingOrder).
            ThenBy(item => item.name.ToLower().IndexOf(input.text)).
            ThenBy(item => item.name).ToList();
            Debug.Log(c[0].name);
            res = c[0].name;
        }    

        return c.Count > 0;
    }
}
