using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraLayer : MonoBehaviour
{
    public LayerMask hide, show;
    private void Start()
    {
        GetComponent<Camera>().cullingMask = hide;
        PositionUnit.PositionInterface.onStatusChange += OnStatusChange;
    }

    void OnStatusChange(PositionUnit.PosStatus status)
    {
        if (status == PositionUnit.PosStatus.normal)
        {
            GetComponent<Camera>().cullingMask = show;
        }
        else
        {
            GetComponent<Camera>().cullingMask = hide;
        }
    }
}
