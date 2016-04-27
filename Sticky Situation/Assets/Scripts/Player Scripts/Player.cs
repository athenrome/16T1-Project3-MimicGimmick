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

        CheckInput();

	}

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(MimicMode == false)
            {
                MovePlayerForward();
            }
        }
            
        if (Input.GetKey(KeyCode.S))
        {
            if (MimicMode == false)
            {
                MovePlayerBack();
            }
        }
            
        if (Input.GetKey(KeyCode.A))
        {
            if (MimicMode == false)
            {
                RotatePlayerLeft();
            }
        }
            
        if (Input.GetKey(KeyCode.D))
        {
            if (MimicMode == false)
            {
                RotatePlayerRight();
            }
        }
            
    }

	void MovePlayerForward ()
	{
        transform.Translate(Vector3.forward * -MoveSpeed);
    }

    void MovePlayerBack()
    {
        transform.Translate(Vector3.forward * MoveSpeed);
    }

    void RotatePlayerLeft()
    {
        transform.Rotate(Vector3.up * -RotateSpeed);
    }

    void RotatePlayerRight()
    {
        transform.Rotate(Vector3.up * RotateSpeed);

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
