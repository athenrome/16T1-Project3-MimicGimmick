using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {



	//the following variables where downloaded from the internet as a part of a camera rotation
	//script that used mouse input. This camera style is commonly used in fps games. 
	//the code was found at: http://coffeebreakcodes.com/move-zoom-and-rotate-camera-unity3d/

	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	float rotationY = 0.0f;
	float rotationX = 0.0f;

	//[] means attributes and tooltip allows you to include information to read about a
	//thing when you hover your mouse cursor over it
	[Tooltip(" This requires the player gameobject, it is the Game camera and will rotate around the player that it will also follow, but will not be affected by the rotation of.")]
	public Transform PlayerPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	


//		// really basic mouse movement I got from the internet that allows the camera
//		//to pan left and right by rotating this, the cameras parent object.
//
//		if(Input.GetAxis("Mouse X")<0){
//			//Code for action on mouse moving left
//			transform.Rotate (Vector3.up * -0.5f);
//		}
//		if(Input.GetAxis("Mouse X")>0){
//			//Code for action on mouse moving right
//			transform.Rotate (Vector3.up * 0.5f);
//		}
//		//works but is kinda weird

		//another method that moves based on the mouse input value, not just wether 
		//or not there is movement or not


	

	//this method below takes input from the movement of the mouse and moves the 
		//camera through those inputs

		
				rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
			
				transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		//the issue I then had was that the camera was on the stick insect gameobject
		//and the camera was being moved due to that and the camera movement which I 
		//thought was bad so I decided to make the cameras gameobject follow the player

		this.transform.position = PlayerPos.position;

	}
}
