using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
	public bool taken;
	public int score = 1;


	IEnumerator ReScore()
	{
		yield return new WaitForSeconds (10f);
		taken = false;   
	}
}
