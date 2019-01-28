using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public int Time;
        private void Start()
        {
            Destroy(gameObject, Time);
        }
    }
}
