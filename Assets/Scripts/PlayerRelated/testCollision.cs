using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollision : MonoBehaviour {

    public static testCollision staticCollision;
    public bool Collision = false;
    public List<GameObject> Spawners;


    private void Start()
    {
        staticCollision = this;
        Collision = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Collision = true;
        foreach (GameObject obj in Spawners)
            obj.SetActive(false);
    }
}
