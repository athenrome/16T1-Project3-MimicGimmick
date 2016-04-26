using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public int number = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player") 
		{
			Debug.Log (number);
			//IDK do some mimicing stuff probably

		}

	}
}
