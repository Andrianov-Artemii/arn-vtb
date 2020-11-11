using System;
using System.Collections;
using System.Collections.Generic;
using PositionUnit;
using UnityEngine;

public class FrameController : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        PositionUnit.PositionInterface.onStatusChange += OnStatusChange;
    }

    public void OnStatusChange(PositionUnit.PosStatus status)
    {
        if (status == PositionUnit.PosStatus.normal)
        {
            anim.SetTrigger("Close");
            Destroy(this);
        }
    }
}
