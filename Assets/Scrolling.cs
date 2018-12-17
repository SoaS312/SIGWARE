using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private Rigidbody rb;
    public int speed;
    private int originalSpeed;

    public static Scrolling staticScrolling;

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
        rb.velocity = new Vector3(0, speed, 0);
        if (Move.staticMove.isBouleDeNeige)
        {
            speed = Move.staticMove.rouleSpeed;
        }
        else
        {
            speed = originalSpeed; ;
        }
    }
}
