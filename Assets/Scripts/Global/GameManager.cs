using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance = null;
    //Make it so this script is accesable anywhere in the scene 

    public GameObject highScorePanel;
    public GameObject highScoreList = null;
    public GameObject txtPrefab;


    void Start()
    {
        Instance = this;
        //Load and display HighScores
        LoadHighScorePanel();
    }
    #endregion
    //Restarts current Level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Loads next level
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Loads Previous Level
    public void Prevlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Toggles High scores on and off
    public void ToggleHSActive(bool isOn)
    {
        if (isOn)
            highScorePanel.SetActive(true);
        else
            highScorePanel.SetActive(false);
    }


    public void LoadHighScorePanel()
    {

        // Make sure the scores are loaded
        XMLManager.LoadHighScores();
        
        if (highScoreList != null)
        { 
            // loop though each score in the score list and display it
            foreach (ScoreEntry aScore in XMLManager.scores.list)
            {
                // convert float saved in xml to a time span for display
                TimeSpan time = TimeSpan.FromSeconds(aScore.timeAlive);
                // create a new text object to display the high score
                GameObject tempText = Instantiate(txtPrefab, highScoreList.transform);
                // Set the text of the text field to current high score in the list
                tempText.GetComponentInChildren<Text>().text = aScore.playerName + " | Kills: " + aScore.score + " | Time Alive: " + time.ToString(@"hh\:mm\:ss\:fff");
            }
        }
    }
}
