using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorPicker : MonoBehaviour 
{
	public Color[] Colors;
	public void SetColor (int id)
	{
			PlayerPrefs.SetInt ("TruckColor" + PlayerPrefs.GetInt ("TruckID").ToString (), id);
		
 			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<ColorLoader>().mat.color = Colors [id];
	}
}
