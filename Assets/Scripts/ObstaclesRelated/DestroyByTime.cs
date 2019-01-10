using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public int time;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, time);
		
	}
}
