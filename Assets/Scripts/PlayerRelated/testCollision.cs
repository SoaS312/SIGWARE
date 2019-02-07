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
        public GameObject BonhommeNeigeExplosion;
        public AudioSource audioS;

        private void Start()
        {
            staticCollision = this;
            Collision = false;
            initialPosition = CamTransform.localPosition;
            audioS = this.GetComponent<AudioSource>();
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

            if (other.gameObject.name.Contains("Bonhomme") || other.gameObject.name.Contains("Igloo") || other.gameObject.name.Contains("Jumper"))
            {
                if (other.gameObject.name.Contains("Bonhomme") || other.gameObject.name.Contains("Igloo"))
                    {
                    Move.staticMove.isBouleDeNeige = true;
                    if (other.gameObject.name.Contains("Bonhomme")){
                        Instantiate(BonhommeNeigeExplosion, other.transform.position, transform.rotation);
                    }
                    Destroy(other.gameObject);
                }
                else
                {
                    Move.staticMove.isJumping = true;
                    Move.staticMove.JumpAnimation();
                    audioS.Play(1);
                }
            }
            else
            {
                Move.staticMove.isKO = true;
                shakeDuration = 0.5f;
                Collision = true;
                Move.staticMove.StopGame();
            }
        }
    }
}
