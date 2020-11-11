using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputSelect : MonoBehaviour, ISelectHandler
{
    public UnityEvent act;

    public void OnSelect(BaseEventData data)
    {
        act.Invoke();
    }
}