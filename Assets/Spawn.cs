using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [Header("===Settings===")]
    public Vector3 position;
    public Vector3 size;

    [Header("===Obstacles===")]
    public GameObject[] prefabs;
    public GameObject gameObjectSelected;
    public int index;

	// Use this for initialization
	void Start () {
        position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("l"))
        {
            Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x/2), 0, 0);
            index = Random.Range(0, prefabs.Length);
            gameObjectSelected = prefabs[index];
            Instantiate(gameObjectSelected, Pos, Quaternion.Euler(-90, 0, 0));
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0, 0.5f);
        Gizmos.DrawCube(position, size);
    }
}
