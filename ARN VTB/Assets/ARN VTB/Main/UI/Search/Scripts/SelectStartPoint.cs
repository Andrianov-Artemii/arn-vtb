using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStartPoint : MonoBehaviour
{
    public SearchResultController sec;
    public GameObject ARMap;
    public bool first = true;

    //void Awake()
    //{
    //    sec = GetComponent<SearchResultController>();
    //    sec.OnFirstOpen += StartPoint;
    //    Debug.Log(sec);
    //}



    //void OnDisable()
    //{
    //    sec.OnFirstOpen -= StartPoint;
    //}

    private void OnEnable()
    {
        StartPoint();
        FindObjectOfType<LoadSceneController>().OnScene2Load += StartPoint;
    }

    private void OnDisable()
    {
        FindObjectOfType<LoadSceneController>().OnScene2Load -= StartPoint;
    }



    void StartPoint()
    {
        StartCoroutine(ToPoint());
    }


    IEnumerator ToPoint()
    {
        //ARMap.SetActive(true);

        var childs = GetComponent<SearchResultController>().childs;
        //Debug.Log(childs.Count);
        //if (first)
        //{
        //    yield return new WaitForSeconds(5);
        //    first = false;
        //}
        //else
        //{
        //    //yield return new WaitUntil(() => childs.Count > 0);
        //    yield return null;

        //}

        if (MenuData.point == null && MenuData.point == "")
            yield break;

        yield return new WaitUntil(() => childs.Count > 0);
        int k = 0;
        for (int i = 0; i < childs.Count; i++)
        {
            var si = childs[i].GetComponent<SearchItem>();
            if (si != null)
            {
                if (si.t.text == MenuData.point)
                {
                    //si.Select();
                    si.Tap();
                    GetComponentInParent<SearchInputController>().ChangeState();
                    yield break;
                }
                k++;
            }
        }
        Debug.Log("Нето");
      
        childs[0].GetComponent<SearchItem>().Tap();
        GetComponentInParent<SearchInputController>().ChangeState();
        ARMap.SetActive(false);
    }


}
