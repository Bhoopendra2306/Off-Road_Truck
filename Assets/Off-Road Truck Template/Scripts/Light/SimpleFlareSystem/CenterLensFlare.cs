using UnityEngine;
using System.Collections;

public class CenterLensFlare : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public bool visible;

	void OnBecameInvisible ()
	{
		GetComponentInParent<MeshRenderer> ().enabled = false;
		visible = false;
	}

	void OnBecameVisible ()
	{
		GetComponentInParent<MeshRenderer> ().enabled = true;
		visible = true;
	}
}
