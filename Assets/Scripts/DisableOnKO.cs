using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class DisableOnKO : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {

            if (Move.staticMove.isKO)
                this.gameObject.SetActive(false);

        }
    }
}
