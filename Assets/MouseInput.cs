using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public Camera mainCamera;
    public static MouseInput mouseInputStatic;

    public void Awake()
    {
        mouseInputStatic = this;
    }

    public Vector3 GetMouseWorldPosition(Vector3 screenPosition)
    {

        Vector3 mouseWorldPosition = new Vector3();

        Ray mouseRay = mainCamera.ScreenPointToRay(screenPosition);

        RaycastHit[] hits = Physics.RaycastAll(mouseRay);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<InputSurface>() != null)
            {
                mouseWorldPosition = hit.point;
            }
        }

        return mouseWorldPosition;
    }
}
