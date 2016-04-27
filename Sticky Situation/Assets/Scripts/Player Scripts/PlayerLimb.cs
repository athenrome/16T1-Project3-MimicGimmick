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

    Quaternion currLimbQuaternion;
    float currLimbRotation;
    public float minRotation;
    public float maxRotation;

    public bool limbLocked;
    public bool inPosition;

    public float errorAllownance;

    float targetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateLimb(LimbAction _action, float _targetPos)
    {
        targetPos = _targetPos;

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

    void CheckLimbPosition()
    {
        if(currLimbRotation <= (currLimbRotation += errorAllownance))
        {
            if (currLimbRotation >= (targetPos -= errorAllownance));
            {
                currLockTime -= Time.deltaTime;
            }
        }
    }

    void MoveLimbUp()
    {
        Quaternion newLimbRotation = new Quaternion(transform.position.x, transform.position.y, (limbMoveSpeed * Time.deltaTime), 0);
        

        this.transform.rotation = Quaternion.Slerp(currLimbQuaternion, newLimbRotation, limbMoveSpeed * Time.deltaTime);

        currLimbRotation = currLimbQuaternion.z;
    }

    void PassiveDrop()
    {
        Quaternion newLimbRotation = new Quaternion(transform.position.x, transform.position.y, (passiveDropSpeed * Time.deltaTime), 0);

        this.transform.rotation = Quaternion.Slerp(currLimbQuaternion, newLimbRotation, limbMoveSpeed * Time.deltaTime);

        currLimbRotation = currLimbQuaternion.z;
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