using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIController : MonoBehaviour
{
    public static MainUIController mainUIController;

    public MapPointerController mapPointerController;

    private void Awake()
    {
        mainUIController = this;
    }



    public void SetTarget(Vector3 pos)
    {

        mapPointerController.SetTargetPos(pos);
        MainGameController.mainGameController.SetTarget(pos);
    }

}
