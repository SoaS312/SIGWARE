using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class DestroyVisible : MonoBehaviour
    {

        private void OnBecameInvisible()
        {
            Destroy(gameObject,3);
        }
    }
}
