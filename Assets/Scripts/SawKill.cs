using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawKill : MonoBehaviour {

    private Player player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().Die();
            player.Die();
        }
    }
}
