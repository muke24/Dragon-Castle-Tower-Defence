using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    #region Singleton
    public static PlayerHandler Instance = null;
    //Make it so this script is accessible anywhere in the scene 
    #endregion

    public int curPlayerLife = 100;
    public int maxPlayerLife = 100;

    void Start()
    {
        Instance = this;
    }
    
}
