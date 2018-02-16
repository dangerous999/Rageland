using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("WallChecker").GetComponentInParent<Player>();
    }
	// Player can wall jump if he's touching a wall and isn't grounded
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground")) // All ground/wall materials have Ground tag
        {
            if (player.grounded)
                player.canWallJump = false;
            else // When player isn't grounded and is touching wall he can wall jump
                player.canWallJump = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            if (!player.grounded)
                player.canWallJump = true;
            else
                player.canWallJump = false;
        }  
    }
    // When players wall collider stops colliding with ground
    void OnTriggerExit2D(Collider2D col) 
    {
        if (col.CompareTag("Ground"))
        {
            player.canWallJump = false;
            player.jumpCount = 1; // To give player one more jump mid air
        }
    }
}
