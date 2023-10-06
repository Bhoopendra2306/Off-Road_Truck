using UnityEngine;
using System.Collections;

public class FinishTrigger : MonoBehaviour {

	public GameObject FinishMenu;
	public int AwardedScore = 4300;
	bool Entered;
	public ItemManager manager;

	void Start()
	{

		if (!manager)
			manager = GameObject.FindObjectOfType<ItemManager> ();


	}
	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Player") || col.CompareTag("Item")) {

			if (!Entered) {
				if (FinishMenu)
					FinishMenu.SetActive (true);
				manager.TotalScore += AwardedScore;
				PlayerPrefs.SetInt ("Coins",manager.TotalScore);
				Entered = true;
				StartCoroutine (Finishing ());
			}
		}
	}

	IEnumerator Finishing()
	{
		manager.SaveBestTime ();
		manager.bestTime.text = manager.ReadBestTime ();
		manager.currentTime.text = manager.ReadCurrentTIme ();

		yield return new WaitForSeconds(3f);


		GameObject.FindObjectOfType<VehicleController2017> ().canControl = false;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ().isKinematic = true;

	}
}
