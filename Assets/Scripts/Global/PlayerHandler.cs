using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHandler : MonoBehaviour
{
    #region Singleton
    public static PlayerHandler Instance = null;
    //Make it so this script is accessible anywhere in the scene 
    #endregion
    
    //Global variables for the player
    public static int playerLife = 100;
    public static int playerGold = 100;
    public static int playerScore = 0;
    public static float timeAlive = 0f;

    public GameObject endGamePanel;

    public Text txtGold;
    public Text txtTreasure;
    public InputField inpName;

    public Text txtResults;
    
    void Start()
    {
        Instance = this;
        //Time.timeScale = 3;
    }

    private void Update()
    {
        if (playerLife <= 0)
        {
            //show end game panel
            endGamePanel.SetActive(true);
            //stop game time
            Time.timeScale = 0;
            // show game results
            txtResults.text = "Enemies Killed: " + playerScore + ", Time Survived: " + Math.Round(timeAlive,2).ToString() + " seconds";
        }
        else
        {
            txtGold.text = "Essence: " + playerGold.ToString();
            txtTreasure.text = "Treasure: " + playerLife.ToString();
            // increase time alive
            timeAlive += Time.deltaTime;
        }
    }

    public void EndGame()
    {
        Debug.Log(inpName.text + " " + playerScore + " " + timeAlive);
        //save score to xml file
        XMLManager.AddHighScore(inpName.text, playerScore, timeAlive);

        XMLManager.SaveScore();
        // go back to main menu        
        GameManager.Instance.Prevlevel();
    }


    public void TakeDamage(int dmgAmount)
    {
        //Debug.Log("Lose Life " + dmgAmount);
        playerLife -= dmgAmount;
    }



}
