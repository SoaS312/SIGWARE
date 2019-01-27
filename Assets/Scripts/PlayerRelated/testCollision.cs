using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class testCollision : MonoBehaviour
    {

        public static testCollision staticCollision;
        public bool Collision = false;
        public Transform CamTransform;
        private float shakeDuration = 0f;
        private float shakeMagnitude = 0.5f;
        private float dampingSpeed = 1.0f;
        Vector3 initialPosition;

        private void Start()
        {
            staticCollision = this;
            Collision = false;
            initialPosition = CamTransform.localPosition;
        }

        void Update()
        {
            if (shakeDuration > 0)
            {
                CamTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

                shakeDuration -= Time.deltaTime * dampingSpeed;
            }
            else
            {
                shakeDuration = 0f;
                CamTransform.localPosition = initialPosition;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.name.Contains("Bonhomme"))
            {
                Move.staticMove.isKO = true;
                shakeDuration = 0.5f;
                Collision = true;
                Move.staticMove.StopGame();
            }
            else
            {
                Move.staticMove.isBouleDeNeige = true;
                Destroy(other.gameObject);
            }
        }
    }
}
