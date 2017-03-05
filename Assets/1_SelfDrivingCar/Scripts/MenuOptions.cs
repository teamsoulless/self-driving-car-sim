using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class MenuOptions : MonoBehaviour
{
    static public int resolution = 0;
    private int track = 1;
    private Outline[] outlines;

    public void Start ()
    {
        outlines = GetComponentsInChildren<Outline>();
		Debug.Log ("in menu script "+outlines.Length);
        resolution = 0;
        if (outlines.Length == 0) 
		{
			outlines [0].effectColor = new Color (0, 0, 0);
		} else {
			outlines [1].effectColor = new Color (0, 0, 0);
		}
	}

	public void ControlMenu()
	{
		SceneManager.LoadScene ("ControlMenu");
	}

	public void MainMenu()
	{
		Debug.Log ("go to main menu");
		SceneManager.LoadScene ("MenuScene");
	}

    public void StartDrivingMode()
    {
        CarController.resolution = resolution;
        if (track == 0) {
            SceneManager.LoadScene("LakeTrackTraining");
        } else {
            SceneManager.LoadScene("Thunderhill_train");
        }

    }

    public void StartAutonomousMode()
    {
        if (track == 0) {
            SceneManager.LoadScene("LakeTrackAutonomous");
        } else {
            SceneManager.LoadScene("Thunderhill_autonomous");
        }
    }

    public void SetLakeTrack()
    {
        outlines [0].effectColor = new Color (0, 0, 0);
        outlines [1].effectColor = new Color (255, 255, 255);
        track = 0;
    }

    public void SetThunderhillTrack()
    {
        track = 1;
        outlines [1].effectColor = new Color (0, 0, 0);
        outlines [0].effectColor = new Color (255, 255, 255);
    }

    public void Set320x160()
    {
        Debug.Log("set320x160");
        resolution = 0;
    }

    public void Set1920x1200()
    {
        Debug.Log("set1920x1200");
        resolution = 1;
    }

}
