using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Player player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GroundChecker").GetComponentInParent<Player>();
    }
    void Update()
    {
        Debug.DrawRay(transform.position, -Vector2.up * 0.06f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.06f);
        if ( hit.collider != null )
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Debug.Log("We hit the ground!");
                player.grounded = true;
            }
        }
        else
        {
            Debug.Log("We hit nothing!");
            player.grounded = false;
        }

    }
/*
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
*/
}

