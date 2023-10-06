using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpgradeLoader : MonoBehaviour 
{

	public float[] enginePower,maxSpeed,fuelUpgrade;

	VehicleController2017 truck;

	ItemManager manager;

	public GameObject rain;

	void Start () {


		if (SceneManager.GetActiveScene ().name.Contains ("Garage") ||
		    SceneManager.GetActiveScene ().name.Contains ("Menu")) {
			rain.SetActive (false);


			return;
		}
		
		truck = GetComponent<VehicleController2017> ();
		manager = GameObject.FindObjectOfType<ItemManager> ();

		truck.enginePower = enginePower[PlayerPrefs.GetInt("Engine"+PlayerPrefs.GetInt("TruckID").ToString())];
		truck.maxSpeed = maxSpeed[PlayerPrefs.GetInt("Speed"+PlayerPrefs.GetInt("TruckID").ToString())];

		manager.FualInterval = fuelUpgrade[PlayerPrefs.GetInt("Fuel"+PlayerPrefs.GetInt("TruckID").ToString())];

	}

}
