using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class DisableOnKO : MonoBehaviour
    {
        public void LateUpdate()
        {
            if (Move.staticMove.isKO ||Win_Lose.staticwinlose.Lose)
                this.gameObject.SetActive(false);
        }
    }
}
