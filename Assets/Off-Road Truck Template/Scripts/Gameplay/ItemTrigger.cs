using UnityEngine;
using System.Collections;

public class ItemTrigger : MonoBehaviour 
{
	public ItemManager manager;

	bool alarmed;


	void OnTriggerEnter (Collider col) {
	

		if (col.CompareTag("Item")) {

			if (col.GetComponent<Item> ().taken == false) {
				col.GetComponent<Item> ().taken = true;
				manager.AddScore(col.GetComponent<Item>().score);
				col.GetComponent<Item> ().StartCoroutine ("ReScore");
			}
		}

		if (col.CompareTag("Player")) {
			manager.TotalFuel = 101;
			manager.Alarm.Play ();
		}
	}
	
	void Start () 
	{
		if (!manager)
			manager = GameObject.FindObjectOfType<ItemManager> ();
	}
}
