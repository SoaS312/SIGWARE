using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    public Mesh[] animMeshes;
    public Mesh currentMesh;
    public int index = 0;
    public float timer = 10f;
    public float currentTime;
    public float decreaseTime;

    private void FixedUpdate()
    {
        gameObject.GetComponent<MeshFilter>().mesh = currentMesh;

        if (Input.GetKeyDown("space"))
        {
            timer = 5;
        }

        if (timer > 0)
        {
            timer -= 0.05f;
        }

        if (timer <= 0)
        {
                gameObject.GetComponent<Animator>().Play("New Animation", -1, 0f);
            timer = 5;
        }
    }

    /* // Use this for initialization
     void Start()
     {
         InvokeRepeating("Animation", 1f, 5f);
     }

     private void FixedUpdate()
     {
         //Animation();
     }

     // Update is called once per frame
     void Animation()
     {

         /*if (index < 8)
         {
             index++;
             if (index >= 8)
             {
                 index = 0;
             }
             currentMesh = animMeshes[index];
             gameObject.GetComponent<MeshFilter>().mesh = currentMesh;
         }
     }*/

    /*private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            gameObject.GetComponent<Animator>().Play("New Animation");
        }
    }*/

}
