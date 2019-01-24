using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class testCollision : MonoBehaviour
    {

        public static testCollision staticCollision;
        public bool Collision = false;
        public List<GameObject> Spawners;

        // Transform of the GameObject you want to shake
        public Transform CamTransform;

        // Desired duration of the shake effect
        private float shakeDuration = 0f;

        // A measure of magnitude for the shake. Tweak based on your preference
        private float shakeMagnitude = 0.5f;

        // A measure of how quickly the shake effect should evaporate
        private float dampingSpeed = 1.0f;

        // The initial position of the GameObject
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
            shakeDuration = 0.5f;
            Collision = true;
            foreach (GameObject obj in Spawners)
                obj.SetActive(false);

        }
    }
}
