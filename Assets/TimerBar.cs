using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GRP_07_SkiMadness
{
    public class TimerBar : MonoBehaviour
    {
        public Image TimeFill;
        public float time;
        public float timeAmt = 10;

        // Use this for initialization
        void Start()
        {
            TimeFill = this.GetComponent<Image>();
            time = timeAmt;

        }

        // Update is called once per frame
        void Update()
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                TimeFill.fillAmount = time / timeAmt;
            }
        }
    }
}
