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

    float errorAllownance = 2;

    float targetPos;

	// Use this for initialization
	void Start () {
        currDropTime = timeTilDrop;

    }
	
	// Update is called once per frame
	void Update () {

        currDropTime -= Time.deltaTime;

        if(currDropTime <= 0)
        {
            UpdateLimb(LimbAction.PassiveDrop, targetPos);
        }

        currLimbRotation = this.transform.rotation.eulerAngles.z;
        print(currLimbRotation);
        CheckLimbPosition();
	
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
                PassiveDrop();                 
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
            

            transform.Rotate(transform.rotation.x, transform.rotation.y, (currLimbRotation += (limbMoveSpeed * Time.deltaTime)));
            Debug.Log("Moving Leg " + transform.rotation.z);
            currDropTime = timeTilDrop;
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
            

            transform.Rotate(transform.rotation.x, transform.rotation.y, (currLimbRotation -= (passiveDropSpeed * Time.deltaTime)));
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