using UnityEngine;
using System.Collections;

public class PlayerLimb : MonoBehaviour {

    public LimbPosition bodyPos;

    public float limbMoveSpeed;
    public float passiveDropSpeed;

    public float timeTilLock;
    float currLockTime;

    public float timeTilDrop;
    float currDropTime;

    Quaternion currLimbRotation;
    public float minRotation;
    public float maxRotation;

    public bool limbLocked;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateLimb(LimbAction _action)
    {
        switch(_action)
        {
            case LimbAction.Lock:
                limbLocked = true;
                break;

            case LimbAction.MovingUp:
                MoveLimbUp();
                break;

            case LimbAction.PassiveDrop:
                currDropTime -= Time.deltaTime;

                if(currDropTime <= 0)
                {
                    PassiveDrop();
                    currDropTime = timeTilDrop;
                }
                break;

        }
    }

    void MoveLimbUp()
    {
        Quaternion newLimbRotation = new Quaternion(transform.position.x, transform.position.y, (limbMoveSpeed * Time.deltaTime), 0);
        

        this.transform.rotation = Quaternion.Slerp(currLimbRotation, newLimbRotation, limbMoveSpeed * Time.deltaTime);
    }

    void PassiveDrop()
    {
        Quaternion newLimbRotation = new Quaternion(transform.position.x, transform.position.y, (passiveDropSpeed * Time.deltaTime), 0);

        this.transform.rotation = Quaternion.Slerp(currLimbRotation, newLimbRotation, limbMoveSpeed * Time.deltaTime);
    }
}

public enum LimbAction
{
    StartMimic,
    EndMimic,
    Lock,
    MovingUp,
    PassiveDrop,
}



public enum LimbPosition
{
    UpperRight,
    UpperLeft,
    LowerRight,
    LowerLeft,
}