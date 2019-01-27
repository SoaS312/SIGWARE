using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class CloneBarrière : MonoBehaviour
    {
        public GameObject Spawner;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains("Barrières"))
            {
                Spawner.GetComponent<RepeatScroll>().Spawning();
            }
        }
    }
}