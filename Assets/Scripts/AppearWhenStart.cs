using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class AppearWhenStart : MonoBehaviour
    {
        void Update()
        {
            if(Move.staticMove.speed > 0)
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}