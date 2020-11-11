using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AS
{
    public class SetTargetFrameRate : MonoBehaviour
    {
        public int value;
        private void Awake()
        {
            Application.targetFrameRate = value;
        }
    }
}
