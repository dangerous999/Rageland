using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour {
    private GameMaster gm;
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            Destroy(gameObject);
            gm.score += 1;
        }
    }
}
