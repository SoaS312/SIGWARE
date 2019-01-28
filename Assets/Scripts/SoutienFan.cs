using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class SoutienFan : MonoBehaviour
    {

        public AnimationCurve sautillement;
        private Vector3 iniPos;
        public float maxJumpZ = 10;

        [Header("Timing")]
        public float second;
        public float JumpDuration;

        void Start()
        {
            iniPos = transform.localPosition;
            second = 0;
        }

        void Update()
        {
            Timer();

            if (TimerBar.staticTimer.time <= 0)
            {
                JumpDuration = 0.1f;
            }

        }

        void Timer()
        {
            if (second < JumpDuration)
            {
                second += Time.deltaTime;
                float percentTimer = second / JumpDuration;
                Hopping(percentTimer);
            }

            if (second >= JumpDuration)
            {
                second = 0;
            }
        }

        void Hopping(float jumpPercent)
        {

            float newZ = Mathf.Lerp(iniPos.z, maxJumpZ, sautillement.Evaluate(jumpPercent));
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        }
    }
}
