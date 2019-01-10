﻿using System;
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
    private Vector3 mousePosition;

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
     }

    private void Start()
    {

        wantedPositon = transform.position;
        Cursor.visible = false;
    }

    void Update()
    {
        StaticYZ();
        OnMove();
        StayWithMe();
        StopGame();
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
        /*Vector2 mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);


        if (mouse.x < playerScreenPoint.x)
        {
            Vector3 movement = new Vector3(-1, 0.0f, 0.0f);
            rb.velocity = movement * speed;
        }
        else if (mouse.x > playerScreenPoint.x)
        {
            Vector3 movement = new Vector3(1, 0.0f, 0.0f);
            rb.velocity = movement * speed;
        }

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);*/


        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Mathf.Clamp(Input.GetAxis("Mouse X"),-1,1);
        Debug.Log(moveHorizontal);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement* 4 * speed;

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
        if (testCollision.staticCollision.Collision) { 
        speed = 0;
        rouleSpeed = 0;
    }
    }
}
