using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        else
        {
                speed = originalSpeed; ;
        }

        if (!isSkieur)
        {
            rb.velocity = new Vector3(0, speed* inertie, 0);
            }
        else {
            rb.velocity = new Vector3(0, -speed* inertie, 0);
            }
        }
    }

