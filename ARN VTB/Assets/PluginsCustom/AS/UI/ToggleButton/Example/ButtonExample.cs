using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AS.UI.Example
{
    public class ButtonExample : MonoBehaviour, IButtonAction
    {

        public Color selected, deSelected;

        Button IButtonAction.button()
        {
            return GetComponent<Button>();
        }

        void IButtonAction.deSelect()
        {
            GetComponent<Image>().color = deSelected;
        }

        void IButtonAction.select()
        {
            GetComponent<Image>().color = selected;
        }
    }
}
