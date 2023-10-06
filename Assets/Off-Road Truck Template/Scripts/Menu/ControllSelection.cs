using UnityEngine;
using System.Collections;

public class ControllSelection : MonoBehaviour {

	public void SelectControl (int id) 
	{

		PlayerPrefs.SetInt ("Controll", id);
	}
	public void SetFalse(GameObject target)
	{
		target.SetActive (false);
	}


}
