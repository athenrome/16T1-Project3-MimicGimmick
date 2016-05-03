using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour {

//	public GameObject[] feedingPoints;
	public List<GameObject> feedingPoints;

	public bool foundStanley;
	// Use this for initialization
	void Start () {
		feedingPoints.AddRange (GameObject.FindGameObjectsWithTag ("BirdPathTag"));
//		Debug.Log (feedingPoints.Length);
		foundStanley = false;

	}
	
	// Update is called once per frame
	void Update () {


		//here we fly towards the next food point 
		if (foundStanley == false) {
			transform.LookAt (feedingPoints [0].transform.position);
			transform.Translate (Vector3.forward * 1);
		}

		//this is for attacking Stanley
		if (foundStanley == true) {

		}

	
	}

	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject == feedingPoints [0]) {
			Debug.Log (other.gameObject.name);
			GameObject temp = other.gameObject;
			//this destroys the gameobject and throws an eror before finding the new list and seems
			//horrible as an idea
//			Destroy (feedingPoints [0]);
//			feedingPoints = GameObject.FindGameObjectsWithTag ("Pickup");

			feedingPoints.RemoveAt (0);
			feedingPoints.Add (temp);
		}
		
	}
}
