﻿using UnityEngine;
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

    public GameObject MoveModel;
    public GameObject MimicModel;



	//A list of all the limbs:
    public PlayerLimb UpperLeft;
    public PlayerLimb UpperRight;
    public PlayerLimb LowerLeft;
    public PlayerLimb LowerRight;

    public MimicObject currMimic;

    // Use this for initialization
    void Start () {

        ModeSwitch(true);
        Debug.Log("Mode Switched");
	
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

        if (Input.GetKey(KeyCode.Q))
        {
            if (MimicMode == true)
            {
                UpdateTargetLimb(LimbPosition.UpperLeft, LimbAction.MovingUp);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (MimicMode == true)
            {
                UpdateTargetLimb(LimbPosition.UpperRight, LimbAction.MovingUp);
            }
        }

        if (Input.GetKey(KeyCode.O))
        {
            if (MimicMode == true)
            {
                UpdateTargetLimb(LimbPosition.LowerLeft, LimbAction.MovingUp);
            }
        }

        if (Input.GetKey(KeyCode.P))
        {
            if (MimicMode == true)
            {
                UpdateTargetLimb(LimbPosition.LowerRight, LimbAction.MovingUp);
            }
        }

    }

    void ModeSwitch(bool enableMimic)
    {
        if(enableMimic == true)
        {
            MimicMode = true;
            MimicModel.SetActive(true);
            MoveModel.SetActive(false);
        }
        else
        {
            MimicMode = false;
            MimicModel.SetActive(false);
            MoveModel.SetActive(true);
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
                LowerLeft.UpdateLimb(action, currMimic.LowerLeftPosition);
                break;

            case LimbPosition.LowerRight:
                LowerRight.UpdateLimb(action, currMimic.LowerRightPosition);
                break;

            case LimbPosition.UpperLeft:
                UpperLeft.UpdateLimb(action, currMimic.UpperLeftPosition);
                break;

            case LimbPosition.UpperRight:
                UpperRight.UpdateLimb(action, currMimic.UpperRightPosition);
                break;
        }
    }    
}
