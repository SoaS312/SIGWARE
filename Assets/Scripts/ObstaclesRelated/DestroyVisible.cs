using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class DestroyVisible : MonoBehaviour
    {

        public int time = 3;

        private void OnBecameInvisible()
        {
            Destroy(gameObject, time);
        }
    }
}
