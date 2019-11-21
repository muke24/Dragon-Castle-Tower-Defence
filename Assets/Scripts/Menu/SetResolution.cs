using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
	#region Private Definations

	[Header("Screen Properties")]
	[Space]

	[SerializeField] private int screenWidth;
	[SerializeField] private int screenHeight;
	[SerializeField] private bool isFullScreen;

	#endregion

	public Text resTxt;
	public Button fllScrnBtn;
	public Button applyBtn;
	public Slider resSlider;
	public int resInt;
	public int resTxtInt;

	// Unity Functions
	private void Awake()
	{
		GetRes();
		SetRes();
	}

	private void Start()
	{
		// Show the resolution.
		resTxt.text = Screen.width.ToString() + " " + Screen.height.ToString();
		
	}

	private void GetRes()
	{

		// Gets the current resolution of desktop.
		screenWidth = Screen.currentResolution.width;
		screenHeight = Screen.currentResolution.height;


	}

	private void SetRes()
	{

		// Sets the resolution of game.
		isFullScreen = true;
		Screen.SetResolution(screenWidth/resInt, screenHeight/resInt, isFullScreen);

	}

	private void Update()
	{
		// Show the resolution.
		//resTxt.text = Screen.width.ToString() + " x " + Screen.height.ToString();
		resTxt.text = Screen.width.ToString() + " x " + Screen.height.ToString();

		int.TryParse(resTxt.text, out resTxtInt);

		fllScrnBtn.onClick.AddListener(TaskOnClick);
		applyBtn.onClick.AddListener(TaskOnClickApply);

		resInt = (int)resSlider.value;

	}

	public void TaskOnClick()
	{
		if (isFullScreen == true)
		{
			isFullScreen = false;
		}
		else isFullScreen = true;

		//------------------------------------

		if (isFullScreen == true)
		{
			isFullScreen = true;
			fllScrnBtn.GetComponent<Image>().color = Color.green;
		}
		if (isFullScreen == false)
		{
			isFullScreen = false;
			fllScrnBtn.GetComponent<Image>().color = Color.red;
		}

		
	}
	public void TaskOnClickApply()
	{
		Screen.SetResolution(screenWidth / resInt, screenHeight / resInt, isFullScreen);
	}
}
