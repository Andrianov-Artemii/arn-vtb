using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AS.UI
{
    public class ToggleButton : MonoBehaviour, IButtonAction
    {

        public UnityEngine.Events.UnityEvent onSelect, onDeSelect;

        Button button;
        Button IButtonAction.button()
        {
            if (!button)
                button = GetComponent<Button>();
            return button;
        }

        void IButtonAction.deSelect()
        {
            onDeSelect.Invoke();
        }

        void IButtonAction.select()
        {
            onSelect.Invoke();
        }
    }
}
