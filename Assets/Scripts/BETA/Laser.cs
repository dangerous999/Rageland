using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public bool isOn;
    // Determines how long the laser stays on/off in seconds
    public float interval = 2.0f;
    public float timer;
    private Animator anim;
    public GameObject k;

    void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
        
        // Set timer to interval
        timer = interval;
        // Default state is on
        isOn = true;
	}

    void Update()
    {
        anim.SetBool("On", isOn);
        // Reduce timer until it reaches zero then switch state and reset timer
        timer -= Time.deltaTime;

        if (isOn)
        {
            k.SetActive(true);
        }
        else k.SetActive(false);

        if (timer <= 0f)
        {
            timer = interval;
            isOn = !isOn;
            
        }
    }
    /*
    void Update()
    {
        anim.SetBool("On", isOn);
        // Reduce timer until it reaches zero then switch state and reset timer
        timer -= Time.deltaTime;

        if ( timer <= 0f)
        {
            timer = interval;
            isOn = !isOn;
        }
    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if ( isOn )
            {
                col.GetComponent<Player>().Die();
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isOn)
            {
                col.GetComponent<Player>().Die();
            }
        }
    }


}
