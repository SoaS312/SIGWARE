using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class DisableOnVictory : MonoBehaviour
    {

        public void LateUpdate()
        {
            if (Win_Lose.staticwinlose.Victory)
                this.gameObject.SetActive(false);
        }
    }
}
