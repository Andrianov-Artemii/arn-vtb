using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMap : MonoBehaviour
{

    private void OnEnable()
    {
        var ls = FindObjectOfType<LoadSceneController>();
        ls.OnScene2Map += StartSession;
        if (ls.isMap)
            StartSession();
    }

    void StartSession()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Button>().onClick.Invoke();

    }
}
