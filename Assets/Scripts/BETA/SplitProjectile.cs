using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitProjectile : MonoBehaviour {

    public Vector2 right = Vector2.right;
    public Vector2 left = Vector2.left;
    public Vector2 up = Vector2.up;
    public Vector2 down = Vector2.down;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    //
    // USE LOCAL POSITON/ROTATION
    //
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
if (!col.isTrigger) { 
        if (col.CompareTag("Ground"))
        {
            GameObject clone1 = Instantiate(bullet, col.transform.position, col.transform.rotation);
            clone1.GetComponent<Rigidbody2D>().velocity = (right + up) * bulletSpeed;

            GameObject clone2 = Instantiate(bullet, col.transform.position, col.transform.rotation);
            clone1.GetComponent<Rigidbody2D>().velocity = (left + up) * bulletSpeed;

            GameObject clone3 = Instantiate(bullet, col.transform.position, col.transform.rotation);
            clone1.GetComponent<Rigidbody2D>().velocity = (right) * bulletSpeed;

            Destroy(gameObject);
        }
        if (col.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }


    }
}
