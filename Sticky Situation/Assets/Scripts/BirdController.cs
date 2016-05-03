using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	public GameObject[] feedingPoints;

	// Use this for initialization
	void Start () {
		feedingPoints = GameObject.FindGameObjectsWithTag ("Pickup");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
