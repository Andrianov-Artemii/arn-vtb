using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPosition : MonoBehaviour
{
    public RectTransform input;

    void Start()
    {
        StartCoroutine(SetPosition());
    }

    IEnumerator SetPosition()
    {
        input = GetComponent<SearchResultController>().input.GetComponent<RectTransform>();
        var rectTransform = GetComponent<RectTransform>();
        var p = rectTransform.parent;
        rectTransform.SetParent(input);
        rectTransform.position = input.position;
        rectTransform.offsetMin = new Vector2(0, rectTransform.offsetMin.y);
        rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y);
        //rectTransform.position -= new Vector3(0, input.sizeDelta.y, 0);
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, -input.sizeDelta.y / 2, rectTransform.localPosition.z);

        yield return new WaitForEndOfFrame();
        rectTransform.SetParent(p);
    }



}
