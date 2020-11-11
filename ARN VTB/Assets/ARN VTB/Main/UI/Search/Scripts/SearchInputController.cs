using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SearchInputController : MonoBehaviour
{
    public enum openState
    {
        open,
        close,
        moveToOpen,
        moveToClose
    }


    public float tabletInch = 7;
    public float maxWidthPhone;
    public float maxWidthTablet;
    [Space]
    public bool isOpenLock = false;
    public GameObject buttonstate;
    public RectTransform contentRT;
    public RectTransform lineRT;
    public openState currentState = openState.close;
    public AnimationCurve speed;

    [Space]
    public InputField input;
    public Text inputText;

    Vector2 startSize;
    float maxWidth;

    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
    
        startSize = lineRT.rect.size;
        rt = GetComponent<RectTransform>();
        if (isOpenLock)
        {
            ChangeState();
            buttonstate.SetActive(false);
        }

    }

    public void Open()
    {
        if (currentState == openState.close)
        {
            currentState = openState.moveToOpen;
            StartCoroutine(ChangeState(openState.open));
        }
        else if (currentState == openState.moveToClose)
        {
            currentState = openState.moveToOpen;
        }
    }

    public void Close()
    {
        if (currentState == openState.open)
        {
            BeforeClose();
            currentState = openState.moveToClose;
            StartCoroutine(ChangeState(openState.close));
        }
        else if (currentState == openState.moveToOpen)
        {
            currentState = openState.moveToClose;
        }
    }

    public void ChangeState()
    {
        if ((currentState == openState.open || currentState == openState.moveToOpen) && !isOpenLock) 
        {
            Close();
        }
        else if (currentState == openState.close || currentState == openState.moveToClose)
        {
            Open();
        }
    }

    IEnumerator ChangeState(openState state)
    {
        float dI = Mathf.Sqrt(Screen.height * Screen.height + Screen.width * Screen.width) / Screen.dpi;
        maxWidth = (dI > tabletInch || Screen.orientation == ScreenOrientation.Landscape) ? maxWidthTablet : maxWidthPhone;
        if (state == openState.open)
        {
            BeforeOpen();
        }

        while (currentState != state)
        {
            MoveTo(ref currentState);
            yield return null;
        }

        if (currentState == openState.open)
        {
            AfterOpen();
        }
        else if (currentState == openState.close)
        {
            AfterClose();
        }
    }

    float getDelta(float p)
    {
        return 200 * speed.Evaluate(Mathf.Clamp01(p)) * Time.deltaTime;
    }

    void MoveTo(ref openState state)
    {
        float min = Mathf.Min(maxWidth, rt.rect.size.x);
        float bounds = (lineRT.sizeDelta.x - startSize.x) / (min - startSize.x);
        switch (state)
        {
            case openState.moveToOpen:
                float newSize = lineRT.sizeDelta.x + getDelta(bounds);
                if (newSize > min)
                {
                    lineRT.sizeDelta = new Vector2(min, startSize.y);
                    state = openState.open;
                }
                else
                {
                    lineRT.sizeDelta = new Vector2(newSize, startSize.y);
                }
                break;

            case openState.moveToClose:
                newSize = lineRT.sizeDelta.x - getDelta(1 - lineRT.sizeDelta.x / min);
                if (newSize < startSize.x)
                {
                    lineRT.sizeDelta = new Vector2(startSize.x, startSize.y);
                    state = openState.close;
                }
                else
                {
                    lineRT.sizeDelta = new Vector2(newSize, startSize.y);
                }
                break;
        }
    }

    void BeforeOpen()
    {
        contentRT.sizeDelta = Vector2.right * Mathf.Min(maxWidth, rt.rect.size.x);
        inputText.enabled = true;
    }

    void BeforeClose()
    {
        inputText.text = input.text;
        input.gameObject.SetActive(false);
    }

    void AfterOpen()
    {
        input.gameObject.SetActive(true);
        input.GetComponent<Mopsicus.Plugins.MobileInputField>().SetFocus(true);
    }

    void AfterClose()
    {
        inputText.enabled = false;
    }
}
