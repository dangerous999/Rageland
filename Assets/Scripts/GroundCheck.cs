using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Player player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GroundChecker").GetComponentInParent<Player>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.CompareTag("Ground"))
        {
            player.grounded = true;
            player.hasJumped = false;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground") && player.hasJumped == false)
            player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col )
    {
        if (col.CompareTag("Ground"))
            player.grounded = false;
    }
}

