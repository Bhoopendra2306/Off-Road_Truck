using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VehicleSelect : MonoBehaviour
{
	public GameObject[] vehicles;
	public Transform point;
	public int[] Values;
	public GameObject Lock, Shop, Buy;
	int ID;
	public Text TotalScore, VehicleValue;
	public GameObject Loading;

	public string LevelNameDay = "MainLevel",LevelNameNight = "MainLevel";


	void Start ()
	{
		
		ID = PlayerPrefs.GetInt ("TruckID");

		Instantiate (vehicles [ID], point.position, point.rotation);

		TotalScore.text = PlayerPrefs.GetInt ("Coins").ToString ();

		VehicleValue.text = Values [ID].ToString ();

			if (PlayerPrefs.GetInt ("Truck" + ID.ToString ()) == 3) {
				Lock.SetActive (false);
				Buy.SetActive (false);
			} else {
				Lock.SetActive (true);
				Buy.SetActive (true);
			}

	}
	public void NextVehicle ()
	{
		if (ID < vehicles.Length - 1)
			ID++;


			PlayerPrefs.SetInt ("TruckID", ID);
		
		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		Instantiate (vehicles [ID], point.position, point.rotation);


			if (PlayerPrefs.GetInt ("Truck" + ID.ToString ()) == 3) {
				Lock.SetActive (false);
				Buy.SetActive (false);
			} else {
				Lock.SetActive (true);
				Buy.SetActive (true);
			}
		VehicleValue.text = Values [ID].ToString ();
	}
	public void PrevVehicle ()
	{

		if (ID > 0)
			ID--;

		PlayerPrefs.SetInt ("TruckID", ID);

		Destroy (GameObject.FindGameObjectWithTag ("Player"));
		Instantiate (vehicles [ID], point.position, point.rotation);

			if (PlayerPrefs.GetInt ("Truck" + ID.ToString ()) == 3) {
				Lock.SetActive (false);
				Buy.SetActive (false);
			} else {
				Lock.SetActive (true);
				Buy.SetActive (true);
			}


		VehicleValue.text = Values [ID].ToString ();

	}
	public void SelectVehicle ()
	{
			if (PlayerPrefs.GetInt ("Truck" + ID.ToString ()) == 3) {

				PlayerPrefs.SetInt ("TruckID", ID);
				Loading.SetActive (true);

				if (PlayerPrefs.GetInt ("NightMode") == 3) { 
					SceneManager.LoadScene ("Off-Road_Day");
				} else {
					SceneManager.LoadScene ("Off-Road_Day");
				}

			}
		
	}
	public void BuyVehicle ()
	{
			if (Values [ID] <= PlayerPrefs.GetInt ("Coins")) {

				PlayerPrefs.SetInt ("Truck" + ID.ToString (), 3);

				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - Values [ID]);
				{
					Lock.SetActive (false);
					Buy.SetActive (false);
				}

				TotalScore.text = PlayerPrefs.GetInt ("Coins").ToString ();



			} else  
				Shop.SetActive (true);
		
	}
}
