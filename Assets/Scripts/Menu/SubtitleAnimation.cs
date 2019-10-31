using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleAnimation : MonoBehaviour
{
	public float Speed = 30f;
	public bool mainMenuEnabled;
	public bool settingsEnabled;
    public GameObject MainMenu;
    public GameObject Settings;

	private Transform target;
	private int wavepointIndex = 0;

	// Start is called before the first frame update
	void Start()
    {
		target = Waypoints.points[0];

		mainMenuEnabled = true;
		settingsEnabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

		if (mainMenuEnabled == true && Vector3.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWaypoint();
		}

        if (MainMenu.activeInHierarchy == true)
        {
            mainMenuEnabled = true;
        }

        if (MainMenu.activeInHierarchy == false)
        {
            mainMenuEnabled = false;
        }

        if (Settings.activeInHierarchy == true)
        {
            settingsEnabled = true;
        }

        if (Settings.activeInHierarchy == false)
        {
            settingsEnabled = false;
        }
    }

	void GetNextWaypoint()
	{
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Vector3 dir = target.position;
            return;
        }
        wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}
}
