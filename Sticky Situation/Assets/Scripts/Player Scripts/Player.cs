using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    

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
