using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public int score;
    public int deaths;

    public Text pointsText;
    public Text deathText;
    public Text InputText;

    void Start()
    {
        if ( SceneManager.GetActiveScene().buildIndex == 1  || SceneManager.GetActiveScene().buildIndex == 0 )
            {
                PlayerPrefs.DeleteKey("Score");
                PlayerPrefs.DeleteKey("Deaths");
                score = 0;
                deaths = 0;
            }
            else
            {
                score = PlayerPrefs.GetInt("Score");
                deaths = PlayerPrefs.GetInt("Deaths");     
            }
    }
    void Update()
    {
        
        if( pointsText.name == "PointText" ){
            PlayerPrefs.SetInt("Score", score);
        }
        if ( deathText.name == "DeathText" ){
            PlayerPrefs.SetInt("Deaths", deaths);
        }
        pointsText.text = ("Score: " + score);
        deathText.text = ("Deaths: " + deaths);



    }

}
