using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour {


    public GameObject EndGameUI;

    // Use this for initialization
    void Start()
    {
        EndGameUI.SetActive(true);
    }


    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
