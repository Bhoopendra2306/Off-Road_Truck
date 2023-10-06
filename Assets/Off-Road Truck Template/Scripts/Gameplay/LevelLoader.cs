using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {

	public GameObject[] Levels;  

	void Start () {

		if (SceneManager.GetActiveScene ().name.Contains ("Garage") ||
			SceneManager.GetActiveScene ().name.Contains ("Menu"))
			return;


		Levels [PlayerPrefs.GetInt ("LevelID")].SetActive (true);
		Levels [PlayerPrefs.GetInt ("LevelID")].transform.parent = null;

	}

}
