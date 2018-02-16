using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public int levelToLoad;

    private GameMaster gm;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        gm.InputText.text = ("");

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.CompareTag("Player") ) // When player enters door collider
        {
            gm.InputText.text = ("[E] to enter"); // Display prompt on screen
            if ( Input.GetKey("e") || Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed key");
                SaveInfo();
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //if (col.CompareTag("Player"))
        //{
            if ( Input.GetKey("e") || Input.GetKeyDown(KeyCode.E) )
            {
            Debug.Log("Pressed key");
            SaveInfo();
                SceneManager.LoadScene(levelToLoad);
            }
        //}
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            gm.InputText.text = ("");
    }

    void SaveInfo()
    {
        PlayerPrefs.SetInt("Score", gm.score);
        PlayerPrefs.SetInt("Death", gm.deaths);
        PlayerPrefs.SetInt("levelReached", levelToLoad);
    }

}
