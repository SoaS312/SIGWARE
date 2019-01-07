using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        startY = transform.position.y;
        startZ = transform.position.z;
        isBouleDeNeige = false;
        staticMove = this;
        rb = GetComponent<Rigidbody>();
     }

    private void Start()
    {

        wantedPositon = transform.position;
    }

    void Update()
    {
        StaticYZ();
        OnMove();
        StayWithMe();
        BouleDeNeige();
    }

    void StaticYZ()
    {
        staticPos.y = startY;
        staticPos.y = startZ;
    }

    void StayWithMe()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x,min,max);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    
    void OnMove()
     {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }


    void BouleDeNeige()
    {
        if (isBouleDeNeige)
        {
            roule -= rouleSpeed; //ideal speed > 20
            rb.rotation = Quaternion.Euler(roule, 0.0f, rb.velocity.x * -tilt);
        }
    }
}
