using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class DestroyByTime : MonoBehaviour
    {

        public int time;

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, time);

        }
    }
}
