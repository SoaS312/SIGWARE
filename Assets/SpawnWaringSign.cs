using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class SpawnWaringSign : MonoBehaviour
    {
        public GameObject WarningSign;
        // Use this for initialization
        void Start()
        {
            Instantiate(WarningSign, new Vector3(transform.position.x, -22, -35), new Quaternion(0,0,0,1));
        }
    }
}
