using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class Scrolling : MonoBehaviour
    {
        private Rigidbody rb;
        public int speed;
        private int originalSpeed;
        public int inertie;

        public static Scrolling staticScrolling;
        public bool isSkieur;

        private void Awake()
        {
            staticScrolling = this;
            speed = Move.staticMove.speed;
            originalSpeed = speed;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (Move.staticMove.isBouleDeNeige)
            {
                speed = Move.staticMove.rouleSpeed;
            }

            if (!isSkieur)
            {
                rb.velocity = new Vector3(0, speed * inertie, 0);
            }
            else
            {
                rb.velocity = new Vector3(0, -speed * inertie, 0);
            }

            StopGame();
        }

        void StopGame()
        {
            if (testCollision.staticCollision.Collision)
            {
                speed = 0;
                originalSpeed = 0;
            }
        }
    }
}

