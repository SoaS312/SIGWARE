using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public SpriteRenderer spr;
    private Color red;
    private Color blue;
    private Color yellow;
    private Color green;
    private Color pink;
    private Color violet;




    // Use this for initialization
    void Start () {

        red = Color.red;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
            other.GetComponent<SpriteRenderer>().color = red;
    }
}
