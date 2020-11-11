using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartAR : MonoBehaviour
{


    private void OnEnable()
    {
        var ls = FindObjectOfType<LoadSceneController>();
        ls.OnScene2AR += StartArSession;
        if (!ls.isMap)
            StartArSession();
    }

    void StartArSession()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<Button>().onClick.Invoke();


    }
}
