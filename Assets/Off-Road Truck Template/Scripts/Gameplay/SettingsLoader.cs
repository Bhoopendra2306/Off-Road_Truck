using UnityEngine;
using System.Collections;

public class SettingsLoader : MonoBehaviour {


	public AudioSource AmbiantSound;

	public GameObject overlay;


	[Header("You need edit script for Amplify Color support")]

	public Camera mainCamera;

	public GameObject fogParticle;



	IEnumerator Start () {


		if (!mainCamera)
			mainCamera = Camera.main;
		
		if (PlayerPrefs.GetInt ("AmbientSound") == 3)
			AmbiantSound.Play ();
		else
			AmbiantSound.Stop ();

		if (PlayerPrefs.GetInt ("Overlay") != 3)
			overlay.SetActive (false);
			mainCamera.farClipPlane = PlayerPrefs.GetFloat ("ViewDistance");

		yield return new WaitForEndOfFrame ();


		if (mainCamera) {
			if (PlayerPrefs.GetInt ("Bloom") == 3) 
				mainCamera.GetComponent<Kino.Bloom> ().enabled = true;
			 else 
				mainCamera.GetComponent<Kino.Bloom> ().enabled = false;
		}


		if (PlayerPrefs.GetInt ("Fog") == 3)
			fogParticle.SetActive (true);
		else
			fogParticle.SetActive (false);



	}
}
