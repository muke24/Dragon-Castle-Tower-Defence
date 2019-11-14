using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGraphics : MonoBehaviour
{
    public Resolution resolution;
    public Text resolutionText;

    // Start is called before the first frame update
    void Start()
    {
        resolutionText = resolution.ToString;
    }

    // Update is called once per frame
    void Update()
    {
        Screen.SetResolution
    }
}
