using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{

    public float speed;
    public float rotatingSpeed = 200f;
    public float lifeTime = 2f;
    float timer;
    GameObject target;
    Rigidbody2D rb2D;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
        speed = GetComponentInParent<MagicTurret>().bulletSpeed;
    }

    void Update()
    {
        /*
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
            timer = 0f;
        }
        */
    }

    void FixedUpdate()
    {
        Vector2 point2Target = transform.position - target.transform.position;
        point2Target.Normalize();

        float value = Vector3.Cross(point2Target, transform.up).z;
        rb2D.angularVelocity = rotatingSpeed * value;
        rb2D.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D( Collider2D col )
    {
        if ( col.CompareTag("Player")) {
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("MagicBullet");
            foreach (GameObject bullet in bullets){
                GameObject.Destroy(bullet);
            }
            col.GetComponent<Player>().Die();
        }
        else if (col.CompareTag("Ground")){
            Destroy(gameObject);
        }
    }



}



