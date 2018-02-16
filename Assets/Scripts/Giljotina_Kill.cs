using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giljotina_Kill : MonoBehaviour {

    private Player player;
    public bool detected = true;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            detected = true;
//            col.GetComponent<Player>().Die();
            player.Die();
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
            detected = true;
            player.Die();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        detected = false;
    }
    
}
