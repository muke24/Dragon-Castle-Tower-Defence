using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
	#region Private Definations

	[Header("Screen Properties")]
	[Space]

	[SerializeField] private float screenWidth;
	[SerializeField] private float screenHeight;
	[SerializeField] private bool isFullScreen;

	#endregion

	public Text resTxt;
	public Button fllScrnBtn;
	public Button applyBtn;
	public Slider resSlider;
	public float resSliderFloat;
	public float resWidthFloat;
	public float resHeightFloat;

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
		(int)((float)Screen.SetResolution(screenWidth/ resSliderFloat, screenHeight / resSliderFloat, isFullScreen);

	}

	private void Update()
	{
		// Show the resolution.
		//resTxt.text = Screen.width.ToString() + " x " + Screen.height.ToString();

		float.TryParse(resTxt.text, out resWidthFloat);

		fllScrnBtn.onClick.AddListener(TaskOnClick);
		applyBtn.onClick.AddListener(TaskOnClickApply);

		resSliderFloat = resSlider.value;

		resWidthFloat = (int)((float)Screen.currentResolution.width / resSliderFloat);
		resHeightFloat = (int)((float)Screen.currentResolution.height / resSliderFloat);

		resTxt.text = resWidthFloat.ToString() + " x " + resHeightFloat.ToString();
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
		Screen.SetResolution(screenWidth / resSliderFloat, screenHeight / resSliderFloat, isFullScreen));

	}
}
