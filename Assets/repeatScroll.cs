using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatScroll : MonoBehaviour
{

    private BoxCollider groundCollider;       
    private float groundHorizontalLength;       

    //Awake is called before Start.
    private void Awake()
    {
        
        groundCollider = GetComponent<BoxCollider>();

        groundHorizontalLength = groundCollider.size.y;
    }

    //Update runs once per frame
    private void Update()
    {
        
        if (transform.position.y < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {

        Vector3 groundOffSet = new Vector3(0, groundHorizontalLength * 2f, 0);

        transform.position = (Vector3)transform.position + groundOffSet;
    }
}