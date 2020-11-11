using System.Collections;
using System.Collections.Generic;
using AS.UI;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IButtonAction
{
    public Color selectedColor, deselectedColor;
    public Text text;

    Button IButtonAction.button()
    {
        return GetComponent<Button>();
    }

    void IButtonAction.deSelect()
    {
        text.fontStyle = FontStyle.Normal;
        text.color = deselectedColor;
    }

    void IButtonAction.select()
    {
        text.fontStyle = FontStyle.Bold;
        text.color = selectedColor;
    }
}
