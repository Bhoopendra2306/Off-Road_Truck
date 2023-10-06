using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour 
{
	GameObject mainCamera;

	[Header("The first slot should be empty")]
	[Header("Because is used for Main camera")]
	[Space(3)]

	[Header("Camera List :")]
	public GameObject[] cameras;

	int currentCamera = 0;

	FlareLookAt[] flares;


	void Start()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag ("Flare");

		flares = new FlareLookAt[temp.Length];


		for (int a = 0; a < temp.Length; a++)
			flares[a] = temp [a].GetComponent<FlareLookAt> ();


		mainCamera = GameObject.Find("Main Camera");

		cameras [0] = mainCamera;

	}
	
	public void NextCamera () {
		if (currentCamera < cameras.Length-1)
			currentCamera++;
		else
			currentCamera = 0;

		SelectCamera (currentCamera);
	}

	void SelectCamera(int id)
	{

		for (int a = 0; a < cameras.Length; a++)
			cameras [a].SetActive (false);
	
		cameras [id].SetActive (true); 

		for (int a = 0; a < flares.Length; a++)
			flares [a].cam = cameras [id].transform;
	}
}
