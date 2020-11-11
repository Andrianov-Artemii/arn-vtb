using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{

    const string FIRST_START_KEY = "FirstStart";

    public GameObject StartScreen;
    public GameObject Scene1;
    public bool isMap;

    public event System.Action OnScene2Load;
    public event System.Action OnScene2Map;
    public event System.Action OnScene2AR;

    //public GameObject Scene2;

    // Start is called before the first frame update
    //    void Start()
    //    {

    //        if (PlayerPrefs.HasKey(FIRST_START_KEY))
    //        {
    //#if UNITY_ANDROID
    //            ARUnit.ARInterface.RequestCheckAndroidSupport(StartLoad);
    //#else
    //            StartLoad();
    //#endif
    //        }
    //        else
    //        {

    //#if UNITY_ANDROID
    //            ARUnit.ARInterface.RequestCheckAndroidSupport(() => { StartScreen.SetActive(true); });
    //#else
    //            StartScreen.SetActive(true);
    //#endif

    //        }

    //    }

    public void StartAsFiz()
    {
        SelectMode(PersoneModeType.fiz);
    }

    public void StartAsVIP()
    {
        SelectMode(PersoneModeType.vip);
    }

    void SelectMode(PersoneModeType mode)
    {
        PlayerPrefs.SetInt(FIRST_START_KEY, 1);
        PersoneMode.current = mode;
        StartLoad();
    }

    public void StartWithMode()
    {
        PersoneMode.current = (PersoneModeType) MenuData.mode;
        StartLoad();
    }

    public void StartLoad(bool map = false)
    {
        //SceneManager.LoadScene("Main");


        Scene m = SceneManager.GetSceneByName("Main");
        if (!m.isLoaded)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        }
        else
        {
            Scene1.SetActive(false);
            var s2 = FindObjectOfType<SimpleLoadScene>().Scene2;
            s2.SetActive(true);

        }

        if (OnScene2Load != null)
            OnScene2Load.Invoke();

        isMap = map;

        if (map && OnScene2Map != null)
        {
            OnScene2Map.Invoke();
        }

       

        if (!map && OnScene2AR != null)
        {
            OnScene2AR.Invoke();
        }

    }
}
