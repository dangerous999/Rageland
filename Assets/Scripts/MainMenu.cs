using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject MainMenuUI;
    public GameObject LevelSelectUI;
    public Button[] levelButtons;

    // Use this for initialization
    void Start () {

        // Unlockable levels
        int levelReached = PlayerPrefs.GetInt("levelReached");
        for (int i = 1; i < levelButtons.Length; i++) // Starts at 1 because level 1 is always unlocked so no need to check
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
 
        MainMenuUI.SetActive(true);
        LevelSelectUI.SetActive(false);
    }


    public void Exit()
    {
        Application.Quit();
    }
    public void Levels()
    {
        MainMenuUI.SetActive(false);
        LevelSelectUI.SetActive(true);
    }
    public void LevelsToMain()
    {
        MainMenuUI.SetActive(true);
        LevelSelectUI.SetActive(false);
    }
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        SceneManager.LoadScene(5);
    }
    public void Level6()
    {
        SceneManager.LoadScene(6);
    }
    public void Level7()
    {
        SceneManager.LoadScene(7);
    }
    public void Level8()
    {
        SceneManager.LoadScene(8);
    }
    public void Level9()
    {
        SceneManager.LoadScene(9);
    }
    public void Level10()
    {
        SceneManager.LoadScene(10);
    }



}
