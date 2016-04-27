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

    public void UpdateTargetLimb(LimbPosition targetLimb, LimbStatus action)
    {
        float moveDistance = 0;
        bool limbLock = false;

        switch(action)
        {
            case LimbStatus.Locked:
                break;

            case LimbStatus.PassiveDrop:
                break;

            case LimbStatus.MovingUp:
                break;
        }

        switch(targetLimb)
        {
            case LimbPosition.LowerLeft:
                
                break;

            case LimbPosition.LowerRight:
                break;

            case LimbPosition.UpperLeft:
                break;

            case LimbPosition.UpperRight:
                break;
        }
    }    
}
