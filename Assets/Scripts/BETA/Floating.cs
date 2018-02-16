using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {

    float originalY;
    public float floatStrength = 1;

	void Start ()
    {
        this.originalY = this.transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localPosition = new Vector3(transform.localPosition.x,
                                              originalY + Mathf.Sin(Time.time) * floatStrength,
                                              transform.position.z);	
	}
}
