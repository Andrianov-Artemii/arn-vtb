using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAREventStart : MonoBehaviour
{
    //IEnumerator Start()
    //{
    //    yield return new WaitForSeconds(3);
    //    StartAR();
    //}

    public void StartAR()
    {
        if (ARUnit.ARInterface.ARStatus != ARUnit.ARStatus.Initializing || ARUnit.ARInterface.ARStatus != ARUnit.ARStatus.Running)
        {
            ARUnit.ARInterface.StartARSession();
        }
    }


    public void StopAR()
    {

            ARUnit.ARInterface.StopARSession();
    }
}
