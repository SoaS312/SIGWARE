using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class Jumping : MonoBehaviour
    {

        public AnimationCurve sautillement;
        private Vector3 iniPosZ;
        private Vector3 iniScale;
        public float maxJumpZ = 10;
        public float maxScale = 2;

        [Header("Timing")]
        public float second;
        public float JumpDuration;

        void Start()
        {
            iniPosZ = transform.localPosition;
            iniScale = transform.localScale;
            second = 100;
        }
        void Update()
        {
            Timer();
            if (Move.staticMove.isJumping)
            {
                second = 0;
            }
        }

        void Timer()
        {
            if (second < JumpDuration)
            {
                second += Time.deltaTime;
                float percentTimer = second / JumpDuration;
                Hopping(percentTimer);
                GetComponent<Collider>().enabled = false;
                //Move.staticMove.Traily.enabled = false;
                GetComponent<TrailEffect>().enabled = false;
            }

            if (second >= JumpDuration)
            {
                GetComponent<Collider>().enabled = true;
                //Move.staticMove.Traily.enabled = true;
                //GetComponent<TrailEffect>().enabled = true;
                //GetComponent<TrailEffect>().enabled = true;
            }
        }

        void Hopping(float jumpPercent)
        {

            float newZ = Mathf.Lerp(iniPosZ.z, maxJumpZ, sautillement.Evaluate(jumpPercent));
            float newScaleZ = Mathf.Lerp(iniScale.z, maxScale, sautillement.Evaluate(jumpPercent));
            float newScaleY = Mathf.Lerp(iniScale.y, maxScale, sautillement.Evaluate(jumpPercent));
            float newScaleX = Mathf.Lerp(iniScale.x, maxScale, sautillement.Evaluate(jumpPercent));
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
            transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
        }
    }
}
