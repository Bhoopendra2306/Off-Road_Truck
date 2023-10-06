using UnityEngine;
using System.Collections;

public class VehicleHorn : MonoBehaviour {

	public AudioSource hornSource;
	public AudioClip horn, airBrake;

	public void HornOn()
	{
		if (!hornSource.isPlaying) {
			hornSource.clip = horn;	
			hornSource.Play ();
		}
	}
	public void HornOff()
	{
		hornSource.clip = airBrake;	
		hornSource.Play ();


	}
}
