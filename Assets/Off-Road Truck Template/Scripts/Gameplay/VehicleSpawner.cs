using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] vehicles;
	public Transform spawnPoint;
	void Awake () 
	{
		Instantiate (vehicles [PlayerPrefs.GetInt ("TruckID")], spawnPoint.position, spawnPoint.rotation);
	}
}
