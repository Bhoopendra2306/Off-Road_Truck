using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerUp : MonoBehaviour {

	float  startTime ;
	string  textTime ;
	
	 float guiTime; 
	float  minutes ;
	float  seconds ;
	public Text textField ;


	void Start() {
		startTime = Time.time;
	}
	   



	void Update () {
		guiTime = Time.time - startTime;
		minutes = Mathf.Floor ( guiTime / 60); 
		seconds = Mathf.Floor (guiTime % 60);

		textTime = string.Format ("{0:00}:{1:00}", minutes, seconds);
		textField.text = textTime;
	}
}
