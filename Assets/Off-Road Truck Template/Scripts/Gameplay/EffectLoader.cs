using UnityEngine;
using System.Collections;

public class EffectLoader : MonoBehaviour 
{
		void Start (){
		
		if (PlayerPrefs.GetInt ("Bloom") == 3) 
			GetComponent<Kino.Bloom> ().enabled = true;
		else
			GetComponent<Kino.Bloom> ().enabled = false;
	}
}
