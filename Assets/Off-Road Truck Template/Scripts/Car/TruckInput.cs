//--------------------------------------------------------------
//
//                    Off-Road Truck Kit
//          Writed by AliyerEdon in fall 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for manage mobile input system

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TruckInput : MonoBehaviour
{
	[Header("Truck Input Manager")]
	// Main Truck controller handler
	TruckController truckController;

	// Camera controller (for switching button)
	CameraSwitch camSwitch;

	// Internal values for Throttle,Steer,Brake and ...
	[HideInInspector]public float SteerInput, ThrottleInput, BrakeInput;

	// Is game started?
	bool started;

	// Helper arrow handler for acitivate ans deActivate;
	[HideInInspector]public GameObject helperArrow;

	// Reversing alarm
	[HideInInspector]public AudioSource reverseAlarm;

	// Find player after Truck spawned
	IEnumerator Start ()
	{

		yield return new WaitForEndOfFrame();


		camSwitch = GameObject.FindObjectOfType<CameraSwitch> ();

		// Find Truck by tag
		truckController = GameObject.FindGameObjectWithTag ("Player").GetComponent<TruckController> ();

		// Game is now started
		started = true;

		reverseAlarm = truckController.reverseAlram;
	}

	bool ReverseGear;

	void Update ()
	{
		if (started) 
		{

			SteerInput = Input.GetAxis("Horizontal");
		


			// Send input values to TruckController script
			truckController.Move (SteerInput, ThrottleInput, BrakeInput);

			// Keyboard controlling
			truckController.InputKeyboard();

		if (Input.GetKeyDown (KeyCode.C))
				camSwitch .NextCamera();

			if (Input.GetKeyDown (KeyCode.H))
				GetComponent<VehicleHorn> ().HornOn ();

			if (Input.GetKeyUp (KeyCode.H))
				GetComponent<VehicleHorn> ().HornOff ();

			if (Input.GetKeyDown (KeyCode.Escape))
				GetComponent<Pause> ().SetPause ();


			if (Input.GetKey (KeyCode.Space))
				Brake ();

			if (Input.GetKeyUp (KeyCode.Space))
				Throttle_Brake_Ralease ();
			
		}

	}

	// This is for Throttle UI Button when released
	public void Throttle_Brake_Ralease ()
	{
		ThrottleInput = 0;

		// Light intensity controll
		truckController.backLights [0].intensity = 0;
		truckController.backLights [1].intensity = 0;
		truckController.backLightMaterial.SetFloat ("_Intensity", 0);
	}

	// This is for Throttle UI Button when pressed and released
	public void Brake ()
	{
			ThrottleInput = -1f;

			// Light intensity controll
			truckController.backLights [0].intensity = 1f;
			truckController.backLights [1].intensity = 1f;
			truckController.backLightMaterial.SetFloat ("_Intensity", 0.1f);
	}

	public void ChangeCamera()
	{

		camSwitch.NextCamera ();
	}
}
