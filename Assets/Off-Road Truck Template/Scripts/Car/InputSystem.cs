//--------------------------------------------------------------
//
//                    Truck Parking kit
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour
{


	// Select control type => Touch or keyboard
	public InputType controllType;

	// Automaticcly switch to taget platform controlls
	public bool autoSwitch;

	VehicleController2017 controller;


	float motorInput,steerInput;
	bool handBrake;

	bool reversing;

	[Header("Visuals")]
	public UnityEngine.UI.Image reverseImage;
	public Sprite reverseOffSprite,reverseOnSprite;

	[Header("Components")]
	public SteeringWheel steeringWheel;
	bool sWheelControl;

	public GameObject sWheel;
	public GameObject arrowKeys;
	public GameObject mobileControlls;

	// Accelerometer controlling
	[Header("Accelerometer")]
	public float accelSensibility  = 10f;
	public float accelSmooth = 0.5f;
	Vector3 curAc;
	float GetAxisH = 0f;
	bool accelInput;



	VehicleHorn hornComponent;

	IEnumerator Start ()    
	{
		
		hornComponent = GetComponent < VehicleHorn > ();

		if (PlayerPrefs.GetInt ("Controll") == 0) {
			sWheel.SetActive (false);
			arrowKeys.SetActive (true);
			sWheelControl = false;
		}
		if (PlayerPrefs.GetInt ("Controll") == 1) {
			sWheel.SetActive (true);
			arrowKeys.SetActive (false);
			sWheelControl = true;
		}
		if (PlayerPrefs.GetInt ("Controll") == 2) {
			sWheel.SetActive (false);
			arrowKeys.SetActive (false);
			accelInput = true;
		}

		yield return new WaitForEndOfFrame ();

		controller = GameObject.FindObjectOfType<VehicleController2017> ();

		if (autoSwitch) 
		{
			#if UNITY_EDITOR
			controllType = InputType.Keyboard;
			#else
			{
			#if UNITY_ANDROID || UNITY_IOS
			controllType = InputType.Mobile;
			#else
			controllType = InputType.Keyboard;
			#endif
			}
			#endif
		}

		if (controllType == InputType.Keyboard)
			mobileControlls.SetActive (false);
		else
			mobileControlls.SetActive (true);
	

	}

	void Update () 
	{

		if (!controller)
			return;
		
		if (accelInput) {
			curAc = Vector3.Lerp (curAc, Input.acceleration - Vector3.zero, Time.deltaTime / accelSmooth);
			GetAxisH = Mathf.Clamp (curAc.x * accelSensibility, -1, 1);

			steerInput = GetAxisH;

		}

		if (sWheelControl)
			steerInput = steeringWheel.GetClampedValue ();
		

		if (controllType == InputType.Keyboard) 
		{

			if (Input.GetAxis ("Vertical") > 0) {
				if (reversing)
					motorInput = -1f;
				else 
					motorInput = 1f;
			}
			else 
				motorInput = 0;

			steerInput = Input.GetAxis ("Horizontal");

			if (Input.GetKey (KeyCode.Space) || Input.GetAxis("Vertical") < 0)
				handBrake = true;
			else
				handBrake = false;
			


			if (Input.GetKeyDown (KeyCode.R)) {

				reversing = !reversing;

				if (reverseImage) 
				{
					if (reversing)
						reverseImage.sprite = reverseOnSprite;
					else
						reverseImage.sprite = reverseOffSprite;
				}

			}

			if (Input.GetKey (KeyCode.Escape))
				GetComponent<Pause> ().SetPause ();
		
			if (Input.GetKey (KeyCode.H))
				hornComponent.HornOn ();

			if (Input.GetKeyUp (KeyCode.H)  || Input.GetKeyUp(KeyCode.Space))
				hornComponent.HornOff ();

			if (Input.GetKeyDown (KeyCode.C))
			GameObject.FindObjectOfType<CameraSwitch>().NextCamera ();



		}
		controller.Move (motorInput, steerInput, handBrake);

	}

	public void Throttle()
	{

		if (!reversing)
			motorInput = 1f;
		else
			motorInput = -1f;
		
	}

	public void ThrottleRelease()
	{
		if (controllType == InputType.Mobile) 
			motorInput = 0;

	}

	public void Steer(bool state)
	{

		if (state)
			steerInput = Mathf.Lerp (steerInput, 1f, Time.deltaTime * 34);
		else
			steerInput = Mathf.Lerp (motorInput, -1f, Time.deltaTime * 34);
		
	}

	public void SteerRelease()
	{
		if (controllType == InputType.Mobile) 
			steerInput = 0;

	}

	public void Brake(bool state)
	{

		if (state)
			handBrake = true;
		else
			handBrake = false;
		
	}

	public void ToggleReversing()
	{
		
		reversing = !reversing;

		if (reversing)
			reverseImage.sprite = reverseOnSprite;
		else
			reverseImage.sprite = reverseOffSprite;
		
	}


	public void NextCamera()
	{


		GameObject.FindObjectOfType<CameraSwitch>().NextCamera ();
	}


}
