using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
	public Toggle AmbientSound, ShowFPS,Bloom,amplifyColor,fog;

	public Text resolutionState,qualityState;

	public Slider viewDistance;


	void Start ()
	{
		if (PlayerPrefs.GetInt ("AmbientSound") == 3)
			AmbientSound.isOn = true;
		else
			AmbientSound.isOn = false;
		
		if (PlayerPrefs.GetInt ("Fog") == 3)
			fog.isOn = true;
		else
			fog.isOn = false;
		
		if (PlayerPrefs.GetInt ("ShowFPS") == 3)
			ShowFPS.isOn = true;
		else
			ShowFPS.isOn = false;

		if (PlayerPrefs.GetInt ("Bloom") == 3)
			Bloom.isOn = true;
		else
			Bloom.isOn = false;

		if (PlayerPrefs.GetInt ("AmplifyColor") == 3)
			amplifyColor.isOn = true;
		else
			amplifyColor.isOn = false;

		viewDistance.value = PlayerPrefs.GetFloat ("ViewDistance");

		if (PlayerPrefs.GetInt ("Quality") == 0)
			qualityState.text = "Fastest";
		if (PlayerPrefs.GetInt ("Quality") == 3)
			qualityState.text = "Good";
		if (PlayerPrefs.GetInt ("Quality") == 5)
			qualityState.text = "Fantastic";

		if (PlayerPrefs.GetInt ("Resolution") == 0) {
			PlayerPrefs.SetInt ("Resolution", 720);
			resolutionState.text = "720P";
		} else {
			if (PlayerPrefs.GetInt ("Resolution") == 506)
				resolutionState.text = "506";
			if (PlayerPrefs.GetInt ("Resolution") == 720)
				resolutionState.text = "720P";
			if (PlayerPrefs.GetInt ("Resolution") == 1080)
				resolutionState.text = "1080P";
		}
	}
	public void Set_AmbientSound ()
	{
		StartCoroutine (AmbiantSound_Save ());
	}

	public void SetQualityLevel (int id)
	{
		PlayerPrefs.SetInt ("Quality", id);

		QualitySettings.SetQualityLevel (id, false);

		if (id == 0)
			qualityState.text = "Fastest";
		if (id == 3)
			qualityState.text = "Good";
		if (id == 5)
			qualityState.text = "Fantastic";
	}


	public void SetResolution (int id)
	{
		PlayerPrefs.SetInt ("Resolution", id);

		if (id == 506)
			resolutionState.text = "506";
		if (id == 720)
			resolutionState.text = "720P";
		if (id == 1080)
			resolutionState.text = "1080P";
	}
	IEnumerator AmbiantSound_Save ()
	{
		yield return new WaitForEndOfFrame();

		if (AmbientSound.isOn)
			PlayerPrefs.SetInt ("AmbientSound", 3);
		else
			PlayerPrefs.SetInt ("AmbientSound", 0);
	}

	public void SaveViewDistance()
	{

		PlayerPrefs.SetFloat ("ViewDistance", viewDistance.value);

	}

	public void SetFPS ()
	{
		StartCoroutine (ShowFPS_Save ());
	}

	IEnumerator ShowFPS_Save ()
	{
		yield return new WaitForEndOfFrame();
		if (ShowFPS.isOn)
			PlayerPrefs.SetInt ("ShowFPS", 3);  
		else
			PlayerPrefs.SetInt ("ShowFPS", 0);
	}

	public void SetBloom ()
	{
		StartCoroutine (Bloom_Save ());
	}

	IEnumerator Bloom_Save ()
	{
		yield return new WaitForEndOfFrame();
		if (Bloom.isOn)
			PlayerPrefs.SetInt ("Bloom", 3);  
		else
			PlayerPrefs.SetInt ("Bloom", 0);
	}

	public void SetAmplifyColor ()
	{
		StartCoroutine (AmplifyColor_Save ());
	}

	IEnumerator AmplifyColor_Save ()
	{
		yield return new WaitForEndOfFrame();
		if (amplifyColor.isOn)
			PlayerPrefs.SetInt ("AmplifyColor", 3);  
		else
			PlayerPrefs.SetInt ("AmplifyColor", 0);
	}

	public void SetFog ()
	{
		StartCoroutine (Fog_Save ());
	}

	IEnumerator Fog_Save ()
	{
		yield return new WaitForEndOfFrame();
		if (fog.isOn)
			PlayerPrefs.SetInt ("Fog", 3);  
		else
			PlayerPrefs.SetInt ("Fog", 0);
	}


}
