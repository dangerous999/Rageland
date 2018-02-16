using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Button[] levelButtons;

	// Use this for initialization
	void Start () {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for( int i = 1; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
	}
}
