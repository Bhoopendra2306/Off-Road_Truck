using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour 
{
	public GameObject PauseMenu;

	public Text ScoreText;

	public void SetPause()
	{
		ScoreText.text = GameObject.FindObjectOfType<ItemManager>().TotalScore.ToString();
		PauseMenu.SetActive (true);
		Time.timeScale = 0;
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		PauseMenu.SetActive (false);
	}
	public void Retry()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
	public void Exit(string name)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(name);
	}
}
