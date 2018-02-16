using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 100f;
    void OnTriggerEnter2D(Collider2D col)
    {
        if ( !col.isTrigger ) // To ignore shooting circle of turret itself
        {
            if ( col.CompareTag("Player")) // When player is hit kill him and destroy all bullets
            {
            // Array with all currently spawned bullets
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets)
            {
                GameObject.Destroy(bullet);
            }
            
            col.GetComponent<Player>().Die();
            
            }
            else if ( col.CompareTag("Ground") )// When anything else is hit destroy bullet
            {
                Destroy(gameObject);
            }
        }
        // TODO better definiton of what can destroy bullet
        if (col.CompareTag("Saw"))
        {
            Destroy(gameObject);
        }
    }

}
