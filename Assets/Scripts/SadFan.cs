using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class SadFan : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (testCollision.staticCollision.Collision)
            {
                GetComponent<SoutienFan>().enabled = false;
            }
        }
    }
}
