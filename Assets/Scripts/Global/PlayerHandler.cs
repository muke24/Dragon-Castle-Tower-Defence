using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    #region Singleton
    public static PlayerHandler Instance = null;
    //Make it so this script is accessible anywhere in the scene 
    #endregion

    public static int playerLife = 100;
    public static int playerGold = 100;

    public Text txtGold;
    public Text txtLife;

    void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        txtGold.text = "$" + playerGold.ToString();
        txtLife.text = "LIFE: " + playerLife.ToString();

        if (playerLife <= 0)
        {
            //Save score
            //Death
        }
    }

    public void TakeDamage(int dmgAmount)
    {
        Debug.Log("Lose Life " + dmgAmount);
        playerLife -= dmgAmount;
    }



}
