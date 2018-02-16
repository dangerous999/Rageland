using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Transform enterPortal;
    public Transform exitPortal;
    public Rigidbody2D rb2d;
    public float horizontalOffset = 1f;
    public float verticalOffset = 1f;
    public bool teleported = false;
	// Use this for initialization

    void OnTriggerEnter2D(Collider2D col)
    {
            if (col.CompareTag("Player"))
            { 
            rb2d = col.GetComponent<Rigidbody2D>();
            rb2d.velocity = new Vector3(0f, rb2d.velocity.y);
            rb2d.transform.position = new Vector3(exitPortal.transform.position.x + horizontalOffset,
                                                  exitPortal.transform.position.y + verticalOffset,
                                                  exitPortal.transform.position.z);
            }
    }
}
