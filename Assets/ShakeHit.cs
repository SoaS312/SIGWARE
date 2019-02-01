using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness {
    public class ShakeHit : MonoBehaviour { 
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes
        public Transform trans;



    void Update()
{
        trans.position = new Vector3(Mathf.Sin(Time.time * speed) * amount, transform.position.y, transform.position.z );
    }
}
}