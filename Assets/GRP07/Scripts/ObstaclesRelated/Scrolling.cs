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
            originalSpeed = speed;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            speed = Move.staticMove.speed;

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

            if (TimerBar.staticTimer.time <= 0 && !isSkieur)
            {
                speed = 0;
                rb.velocity = Vector3.zero;
            }
            else if (TimerBar.staticTimer.time <= 0 && isSkieur){
                speed = -originalSpeed * inertie;
            }

            StopGame();
        }

        void StopGame()
        {
            if (testCollision.staticCollision.Collision && !isSkieur)
            {
                speed = 0;
                originalSpeed = 0;
            }
        }
    }
}

