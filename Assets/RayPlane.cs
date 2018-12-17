using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPlane : MonoBehaviour
{
    public GameObject m_test;
    Plane m_Plane;
    Vector3 m_DistanceFromCamera;
    public float m_DistanceZ;

    void Start()
    {
               //This is how far away from the Camera the plane is placed
        m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - m_DistanceZ);

        //Create a new plane with normal (0,0,1) at the position away from the camera you define in the Inspector. This is the plane that you can click so make sure it is reachable.
        m_Plane = new Plane(Vector3.forward, m_DistanceFromCamera);
    }

    void Update()
    {
        //Detect when there is a mouse click
        if (Input.GetMouseButton(0))
        {
            //Create a ray from the Mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Initialise the enter variable
            float enter = 0.0f;

            if (m_Plane.Raycast(ray, out enter))
            {
                //Get the point that is clicked
                Vector3 hitPoint = ray.GetPoint(enter);

                //Move your cube GameObject to the point where you clicked
                m_test.transform.position = hitPoint;
            }
        }
    }
}
