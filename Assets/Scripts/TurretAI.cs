using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100f;
    public float bulletTimer;

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPoint;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Animation control
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);
        RangeCheck();
        if ( target.transform.position.x > transform.position.x) // When player is right of turret, turret looks right
        {
            lookingRight = true;
        }
        else
        {
            lookingRight = false;
        }
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position); // Distance between turret and target(player)
        if ( distance < wakeRange ){
            awake = true;
        }
        else{
            awake = false;
        }
    }

    public void Attack()
    {
        bulletTimer += Time.deltaTime; // Starts at 0 and goes up until shootInterval
        if (bulletTimer >= shootInterval)
        {
            // Returns direction from turret to target 
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            // Creates new bullet at shootPoint position
            GameObject bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            // Shoots bullet in direction of player
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            // Reset bulletTimer
            bulletTimer = 0;
        }
    }
}
