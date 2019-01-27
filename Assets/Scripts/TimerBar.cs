using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP07_SkiMadness
{
    public class TimerBar : MonoBehaviour
    {
       // public Image TimeFill;
        public float time;
        public float timeAmt = 10;
        public GameObject arrivée;
        public static TimerBar staticTimer;
        public List <GameObject> Spawners;
        
        void Start()
        {
            //TimeFill = this.GetComponent<Image>();
            time = timeAmt;
            staticTimer = this;
        }
        
        void Update()
        {
            if (testCollision.staticCollision.Collision)
            {
                time = 10000;
            }

            if (time <= 0.5f)
            {
                arrivée.SetActive(true);

                foreach (GameObject obj in Spawners)
                    obj.SetActive(false);
            }

            if (time > 0)
            {
                time -= Time.deltaTime;
                //TimeFill.fillAmount = time / timeAmt;
            }
        }
    }
}
