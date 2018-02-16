using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    {
        // By default pauseUI is disabled
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause")) // Pause is esc, check project settings in Unity
            paused = !paused; // Turn it on or off with each key press

        if (paused)
        {
            PauseUI.SetActive(true); 
            Time.timeScale = 0; // Freeze time
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1; // Normal time
        }
    }

    public void Resume()
    {
        paused = false;
    }
    // Reloads current scene
    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ); 
    }
    // Goes to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
