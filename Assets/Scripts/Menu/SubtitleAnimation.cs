using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleAnimation : MonoBehaviour
{
    public GameObject mainMenuSubtitle;
    public GameObject menu;
    public GameObject settings;

    public bool optionsEnabled;

    public Animator subtitleAnimation;
    public AnimatorControllerParameter subtitleStopped;

    // Start is called before the first frame update
    void Start()
    {
        optionsEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.activeInHierarchy == true)
        {
            optionsEnabled = false;
        }

        if (settings.activeInHierarchy == true)
        {
            optionsEnabled = true;
        }

        if (optionsEnabled == true)
        {
            mainMenuSubtitle.
        }

    }

}
