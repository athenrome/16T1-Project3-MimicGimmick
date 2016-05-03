using UnityEngine;
using System.Collections;

public class PlayerLimb : MonoBehaviour {

    public LimbPosition bodyPos;

    public float limbMoveSpeed = 5;
    public float passiveDropSpeed = 3;

    float timeTilLock;
    float currLockTime;

    float timeTilDrop = 3;
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

        currDropTime -= Time.deltaTime;

        if(currDropTime <= 0)
        {
            UpdateLimb(LimbAction.PassiveDrop,targetPos);
        }
	
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
        if(currLimbRotation < maxRotation)
        {
            float zRotation = transform.rotation.z;

            transform.Rotate(transform.rotation.x, transform.rotation.y, (zRotation += limbMoveSpeed * Time.deltaTime));
            Debug.Log("Moving Leg " + transform.rotation.z);
            timeTilDrop = 3;
        }
        else
        {
            Debug.Log("At max pos");
        }
        
    }

    void PassiveDrop()
    {
        if (currLimbRotation > minRotation)
        {
            float zRotation = transform.rotation.z;

            transform.Rotate(transform.rotation.x, transform.rotation.y, (zRotation -= limbMoveSpeed * Time.deltaTime));
            Debug.Log("Dropping Leg");
        }
        else
        {
            Debug.Log("At min pos");
        }
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