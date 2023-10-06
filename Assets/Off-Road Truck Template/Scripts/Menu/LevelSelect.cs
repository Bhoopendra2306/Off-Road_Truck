using UnityEngine;
using System.Collections;   
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
	public GameObject[] Locks;
	public Text TotalCoins;
	public int[] levelValues;
	public GameObject Shop;
	public GameObject LevelSelectMenu, CarSelectMenu;
	public Toggle nightMode;

	public Text[] bestTime;

	void Start ()
	{
		TotalCoins.text = PlayerPrefs.GetInt ("Coins").ToString (); 

		for (int a = 0; a < Locks.Length; a++) {

			if (PlayerPrefs.GetInt ("Level" + a.ToString ()) == 3) 
				Locks [a].SetActive (false);

			float min = PlayerPrefs.GetFloat ("Minutes" + a.ToString ());
			float secn = PlayerPrefs.GetFloat ("Seconds" + a.ToString ());

			string minS, secS;

			minS = min.ToString ();
			secS = Mathf.Floor (secn).ToString ();

			if (min < 10)
				minS = "0" + min.ToString ();

			if (secn < 10)
				secS = "0" + Mathf.Floor (secn).ToString ();


			bestTime [a].text = "Best Time " +  (minS + ":" + secS)
				.ToString ();
		}

		if (PlayerPrefs.GetInt ("NightMode") == 3) 
			nightMode.isOn = true;
		else
			nightMode.isOn = false;
	}
	public void SetNightMode()
	{
		StartCoroutine (SaveNightMode ());
	}
	IEnumerator SaveNightMode()
	{

		yield return new WaitForEndOfFrame();
		if (nightMode.isOn)
			PlayerPrefs.SetInt ("NightMode", 3);  
		else
			PlayerPrefs.SetInt ("NightMode", 0);  
	}



	public void SelectLevel(int id)
	{

		if (PlayerPrefs.GetInt ("Level" + id.ToString ()) == 3) 
		{  
			CarSelectMenu.SetActive (true);
			PlayerPrefs.SetInt ("LevelID", id);
			LevelSelectMenu.SetActive (false);
		} 
		else 
		{
			if (PlayerPrefs.GetInt ("Coins") >= levelValues [id]) 
			{
				Locks [id].SetActive (false);
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - levelValues [id]);
				TotalCoins.text = PlayerPrefs.GetInt ("Coins").ToString ();
				PlayerPrefs.SetInt ("Level" + id.ToString (),3 );
			} 
			else
			Shop.SetActive (true);
		}
	}
}
