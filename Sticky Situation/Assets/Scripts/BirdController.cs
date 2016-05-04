using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour {

//	public GameObject[] feedingPoints;
	public List<GameObject> feedingPoints;
	public float flyingSpeed;
	public float diveSpeed;
	public bool foundStanley;

	public GameObject neutral;
	public GameObject swooping;

	public GameObject Stanley;

	public GameObject myShadow;
	// Use this for initialization
	void Start () {
		feedingPoints.AddRange (GameObject.FindGameObjectsWithTag ("BirdPathTag"));
		Stanley = GameObject.FindGameObjectWithTag ("Player");
		foundStanley = false;
		GameObject MyShadow = Instantiate (myShadow, this.transform.position, this.transform.rotation) as GameObject;
		MyShadow.GetComponent<BirdShadowController> ().BirdParent = this.gameObject;
		MyShadow.GetComponent<BirdShadowController> ().theBird = this.gameObject.transform;

	}
	
	// Update is called once per frame
	void Update () {

	
		//here we fly towards the next food point 
		if (foundStanley == false) {
			transform.LookAt (feedingPoints [0].transform.position);
			transform.Translate (Vector3.forward * flyingSpeed);
			neutral.SetActive (true);
			swooping.SetActive (false);

		}

		//this is for attacking Stanley
		if (foundStanley == true) {

			neutral.SetActive (false);
			swooping.SetActive (true);
			swooping.GetComponent<BirdAttackHitController> ().flyingSpeed = diveSpeed;
			swooping.GetComponent<BirdAttackHitController> ().stanley = Stanley;
		}

	
	}

	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject == feedingPoints [0]) {
//			Debug.Log (other.gameObject.name);
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
