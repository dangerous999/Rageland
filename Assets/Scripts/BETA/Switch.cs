using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject A;
    public GameObject D;
    public bool activates;
    public bool deactivates;

    private GameMaster gm;
    private Collider2D kol;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponentInParent<GameMaster>();
        kol = GetComponent<Collider2D>();
        kol.enabled = true;
        // Ovaj dio je samo da ih rucno ne moramo u unityu gasit ako ga zelis
        if (activates)
        {
            A.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) // When player enters door collider
        {
            gm.InputText.text = ("[E] to activate"); // Display prompt on screen
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
        if (Input.GetKey(KeyCode.E))
        {
            if (activates) // Ako zelimo da taj switch nesto aktivira
            {
                A.SetActive(true); // Ovdje bi u drugom kodu išao for
            }
            if (deactivates) // Ako zelimo da taj switch nesto deaktivira
            {
                D.SetActive(false); // Ovdje bi u drugom kodu išao for
            }
            gm.InputText.text = ("");
            kol.enabled = false;
        }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            gm.InputText.text = ("");
    }
}

