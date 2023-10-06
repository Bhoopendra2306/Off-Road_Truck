using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUtility : MonoBehaviour
{
	
	public int startingScore = 1400;
	public int xResolution = 1280,yResolution = 720;

	void Awake ()
	{
		Screen.SetResolution (xResolution, yResolution, true);

		Camera.main.aspect = 16f / 9f;

		if (PlayerPrefs.GetInt ("FirstRun") != 3) 
		{
			PlayerPrefs.SetInt ("FirstRun", 3);

			PlayerPrefs.SetInt ("Level0", 3);

			PlayerPrefs.SetInt ("AmbientSound", 3);

			PlayerPrefs.SetInt ("Sea", 3);

			PlayerPrefs.SetInt ("Truck0", 3);

			PlayerPrefs.SetInt ("AmplifyColor", 3);

			PlayerPrefs.SetFloat ("ViewDistance", 430f);

			PlayerPrefs.SetInt ("Coins", startingScore);
		}
	}

	void Update ()
	{


		if (Input.GetKeyDown (KeyCode.H)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log ("PlayerPrefs.DeleteAll ();");
		}
		if (Input.GetKeyDown (KeyCode.E))
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 14000);
	}

	public void Exit ()
	{
		Application.Quit ();
	}

	public void SetTrue (GameObject target)
	{
		target.SetActive (true);
	}

	public void SetFalse (GameObject target)
	{
		target.SetActive (false);
	}

	public void ToggleObject (GameObject target)
	{
		target.SetActive (!target.activeSelf);
	}

	public void LoadLevel (string name)
	{
		SceneManager.LoadScene (name);
	}

	public void OpenURL (string val)
	{
		Application.OpenURL (val);
	}
}
