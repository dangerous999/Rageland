using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTurret : MonoBehaviour {


    public Transform target;
    public Transform shootPoint;

    public float shootInterval;
    public float bulletSpeed = 100f;
    public float bulletTimer;
    public GameObject bullet;
	
	// Update is called once per frame
	void Update ()
    {
        bulletTimer += Time.deltaTime; // Starts at 0 and goes up until shootInterval
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Attack();
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Attack();
        }
    }
    void Attack()
    {
        // bulletTimer += Time.deltaTime; // Starts at 0 and goes up until shootInterval
        if (bulletTimer >= shootInterval)
        {
            // Returns direction from turret to target 
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            // Creates new bullet at shootPoint position as child of turret
            GameObject bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation, this.transform);
            // Shoots bullet in direction of player
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            // Reset bulletTimer
            bulletTimer = 0;
        }
    }
}
