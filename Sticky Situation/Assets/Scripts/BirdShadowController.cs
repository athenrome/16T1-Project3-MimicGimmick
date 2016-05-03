using UnityEngine;
using System.Collections;

public class BirdShadowController : MonoBehaviour {
	public GameObject BirdParent;
	public Transform theBird;
	public Transform myPos; 

	public AudioClip birdScreech;
	// Use this for initialization
	void Start () {
		myPos = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (theBird.position.x, 4f, theBird.position.z);
//		this.transform.rotation = Quaternion.Euler (theBird.rotation.x*90, theBird.rotation.y*90, theBird.rotation.z*90);
		this.transform.rotation = theBird.transform.rotation;
}

	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject.name == "Player") {
//			Debug.Log ("I found an " + other.gameObject.name);

			BirdParent.GetComponent<BirdController> ().foundStanley = true;
			AudioSource.PlayClipAtPoint (birdScreech, theBird.position);
		}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.name == "Player") {
//			Debug.Log ("I lost an " + other.gameObject.name);
			BirdParent.GetComponent<BirdController> ().foundStanley = false;
		}
	}
}
