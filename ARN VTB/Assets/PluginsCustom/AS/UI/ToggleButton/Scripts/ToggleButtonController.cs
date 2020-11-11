using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AS.UI
{
    public interface IButtonAction
    {
        Button button();
        void select();
        void deSelect();
    }

    [System.Serializable]
    public class OnChangeEvent : UnityEngine.Events.UnityEvent<int> { }

    public class ToggleButtonController : MonoBehaviour
    {

        public GameObject startValue;
        public OnChangeEvent onChange;
        IButtonAction[] buttons;
        IButtonAction currentSelected;

        private void OnEnable()
        {
            StartAction();
            FindObjectOfType<LoadSceneController>().OnScene2Load += StartAction;

        }

        private void OnDisable()
        {
        FindObjectOfType<LoadSceneController>().OnScene2Load -= StartAction;

        }

        void StartAction()
        {


            buttons = GetComponentsInChildren<IButtonAction>();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].deSelect();
                int t = i;
                buttons[i].button().onClick.AddListener(() =>
                {
                    OnTapButton(buttons[t], t);
                });
            }

            if (startValue)
            {
                IButtonAction st = startValue.GetComponent<IButtonAction>();
                if (buttons.Contains(st))
                {
                    Select(st);
                    return;
                }
            }

            if (buttons.Length > 0)
            {
                Select(buttons[0]);
            }

        }

        void Select(IButtonAction button)
        {
            currentSelected = button;
            currentSelected.select();
        }

        void OnTapButton(IButtonAction button, int id)
        {

            if (currentSelected == button)
                return;
            currentSelected.deSelect();
            Select(button);

            onChange.Invoke(id);
        }
    }
}
