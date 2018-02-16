using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private Player player;
    public bool reached;
    public GameObject flagBlue, flagGold;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        reached = false;
        flagBlue.SetActive(true);
        flagGold.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !reached) // If player entered the Trigger and if he hasn't reached it before
        {
                    flagGold.SetActive(true);  // Change flag color
                    flagBlue.SetActive(false);
                    player.currentSpawnPoint.transform.position = transform.position; // Set player spawnpoint to location of checkpoint
                    reached = true; // to stop reactivating the checkpoint
        }

    }
}