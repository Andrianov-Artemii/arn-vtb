using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public static MainGameController mainGameController;
    public GameObject target;
    public Transform startPos;
    private void Awake()
    {
        target.gameObject.SetActive(false);
        mainGameController = this;
    }

    bool firstTargetSet = false;
    public void SetTarget(Vector3 pos)
    {
        if (PositionUnit.PositionInterface.posStatus != PositionUnit.PosStatus.normal)
        {
            NavUnit.NavInterface.UpdatePath(startPos.position, pos);
        }

        if (!firstTargetSet)
        {
            target.gameObject.SetActive(true);
            firstTargetSet = true;
        }
        target.transform.localPosition = pos + Vector3.up * 0.5f;
    }
}
