using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GRP07_SkiMadness
{
    public class Move : MonoBehaviour
    {

        [Header("Speeds")]
        [Range(0, 10)]
        public int speed = 10;
        int roule;
        [Range(10, 50)]
        public int rouleSpeed = 20;
        public float tilt;

        [Header("Statut")]
        public bool isBouleDeNeige = false;
        public bool isJumping = false;

        [Header("Timer")]
        public float seconds;

        [Header("Misc")]
        float min = 0.05f;
        float max = 0.95f;
        float startY;
        float startZ;
        Vector3 staticPos;
        Transform trans;
        public static Move staticMove;
        Rigidbody rb;
        public Camera Cam;
        public GameObject plane;
        public Vector3 wantedPositon;
        private Vector3 velocity = Vector3.zero;
        public Vector3 wantedPositon2;
        private Vector3 mousePosition;
        public TrailEffect Traily;

        public GameObject MeshNormal;
        public GameObject MeshBoule;
        public GameObject MeshKO;

        private void Awake()
        {
            startY = transform.position.y;
            startZ = transform.position.z;
            isBouleDeNeige = false;
            staticMove = this;
            rb = GetComponent<Rigidbody>();
            MeshNormal.SetActive(true);
            Traily = GetComponent<TrailEffect>();
            seconds = 0;
        }

        private void Start()
        {

            wantedPositon = transform.position;
            Cursor.visible = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }


            seconds += Time.deltaTime;
            StaticYZ();
            OnMove();
            StayWithMe();
            StopGame();
            BouleDeNeige();
            //EnableTrail();
        }

        /*private void EnableTrail()
        {
            if (seconds > 0.5f)
            {
                Traily.enabled = true;
            }
        }*/

        void StaticYZ()
        {
            staticPos.y = startY;
            staticPos.y = startZ;
        }

        void StayWithMe()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, min, max);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }


        void OnMove()
        {
            float moveHorizontal = Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1);

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            rb.velocity = movement * 5 * speed;

            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

        }

        void BouleDeNeige()
        {
            if (isBouleDeNeige)
            {
                MeshBoule.SetActive(true); MeshNormal.SetActive(false);
                roule -= rouleSpeed; //ideal speed > 20
                rb.rotation = Quaternion.Euler(roule, 0.0f, rb.velocity.x * -tilt);
            }
        }

        void StopGame()
        {
            if (testCollision.staticCollision.Collision)
            {
                speed = 0;
                rouleSpeed = 0;
            }
        }
    }
}
