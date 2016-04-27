using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {



	public float LifePoints;
	public Vector3 PlayerPosition;
	public float MoveSpeed;
	public float RotateSpeed;
	public bool PlayerAlive;
	public bool MimicMode;
	public float HiddenLevel;
	public bool PlayerSpotted;

	public float LimbMoveSpeed;




	//A list of all the limbs:
    public PlayerLimb UpperLeft;
    public PlayerLimb UpperRight;
    public PlayerLimb LowerLeft;
    public PlayerLimb LowerRight;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (!MimicMode) {
			MovePlayer ();
		}

	}

	private void MovePlayer ()
	{
		//movement
		if (Input.GetKey (KeyCode.W))
			transform.Translate (Vector3.forward * -MoveSpeed);
		if (Input.GetKey (KeyCode.S))
			transform.Translate (Vector3.forward * MoveSpeed);
		if (Input.GetKey (KeyCode.A))
			transform.Rotate (Vector3.up* -RotateSpeed);
		if (Input.GetKey (KeyCode.D))
			transform.Rotate (Vector3.up* RotateSpeed);
		
	}

    public void UpdateTargetLimb(LimbPosition targetLimb, LimbAction action)
    {
        switch(targetLimb)
        {
            case LimbPosition.LowerLeft:
                LowerLeft.UpdateLimb(action);
                break;

            case LimbPosition.LowerRight:
                LowerRight.UpdateLimb(action);
                break;

            case LimbPosition.UpperLeft:
                UpperLeft.UpdateLimb(action);
                break;

            case LimbPosition.UpperRight:
                UpperRight.UpdateLimb(action);
                break;
        }
    }    
}
