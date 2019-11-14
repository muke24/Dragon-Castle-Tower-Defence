using System;
using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    public void LoadScene(int level)
    {
        SceneManager.LoadScene("Game");
    }
}