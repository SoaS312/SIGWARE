﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class KnockOut : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (testCollision.staticCollision.Collision)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
