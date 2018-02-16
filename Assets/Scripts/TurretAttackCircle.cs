using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackCircle : MonoBehaviour {

    public TurretAI turretAI;
    void Awake() // When turret awakes get TurretAI
    {
        turretAI = gameObject.GetComponentInParent<TurretAI>();
    }
    void OnTriggerStay2D(Collider2D col) // While player is in range
    {
        if ( col.CompareTag("Player") )
        {
            turretAI.Attack();
        }
    }
}
