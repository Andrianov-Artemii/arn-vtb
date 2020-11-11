using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleLoadScene : MonoBehaviour
{
    public GameObject Scene2;

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);      
    }

    public void SwitchScene()
    {
        Debug.Log(SceneManager.GetActiveScene());
        var s1 = FindObjectOfType<LoadSceneController>();
        if (s1 != null)
        {
            s1.Scene1.SetActive(true);
            FindObjectOfType<SearchInputController>().Close();
        }
        //else
        //{
        //    SceneManager.LoadScene("Load");
        //}
        //Scene1.SetActive(true);
        //Scene2.SetActive(false);

    }
}
