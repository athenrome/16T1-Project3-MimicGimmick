using UnityEngine;
using System.Collections;

public class MimicZone : MonoBehaviour {

    public Transform mimicPlayerPosition; //the position wher ethe player will stand in during mimic mode
    public Transform mimicCameraPosition; //the position where the camera will be positioned during mimic mode

    public MimicObject mimicObject;//the object players will be attempting to mimic

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
			
		}

	}

    public void OnCollisionExit(Collision collisionInfo)
    {
        print("No longer in contact with " + collisionInfo.transform.name);
    }
}
