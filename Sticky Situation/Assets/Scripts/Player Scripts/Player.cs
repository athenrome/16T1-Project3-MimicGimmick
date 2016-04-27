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
