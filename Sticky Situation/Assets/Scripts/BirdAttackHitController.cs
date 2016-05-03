using UnityEngine;
using System.Collections;

public class BirdAttackHitController : MonoBehaviour {

	public GameObject stanley;
	public float flyingSpeed;
	public AudioClip eatingSound;
	public GameObject sceneCamera;
	// Use this for initialization
	void Start () {
		sceneCamera = GameObject.Find ("Camera");

	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (stanley.transform.position);
		transform.Translate (Vector3.forward * flyingSpeed);
	}

	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint (eatingSound, this.transform.position);
			sceneCamera.GetComponent<Camera> ().fieldOfView = 5;
			GameObject.Find ("Player").gameObject.GetComponent<Player> ().LifePoints = 0;
			Debug.Log ("load next scene");
		}
	}
}
