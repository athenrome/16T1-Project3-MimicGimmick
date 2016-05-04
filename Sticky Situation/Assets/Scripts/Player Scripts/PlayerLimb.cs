using UnityEngine;
using System.Collections;

public class PlayerLimb : MonoBehaviour {

    public LimbPosition bodyPos;

    float limbMoveSpeed = 15;
    float passiveDropSpeed = 5.5f;

    float timeTilLock;
    float currLockTime;

    float timeTilDrop = 0;
    float currDropTime;

    //Quaternion currLimbQuaternion;
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

        

        if(currDropTime <= 0)
        {
            UpdateLimb(LimbAction.PassiveDrop, targetPos);
        }
        else
        {
            currDropTime -= Time.deltaTime;
        }

        currLimbRotation = this.transform.rotation.eulerAngles.z;
        CheckLimbPosition();
	
	}

    public void UpdateLimb(LimbAction _action, float _targetPos)
    {
        targetPos = _targetPos;
        //print(targetPos);

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

        float minRange = targetPos -= errorAllownance;
        float maxRange = targetPos += errorAllownance;

        if (currLimbRotation >= minRange && currLimbRotation <= maxRange)
        {
            inPosition = true;
            //Debug.Log("In position");
        }
        else
        {
            inPosition = false;
            //Debug.Log("Out of Position");
        }
    }

    void MoveLimbUp()
    {
        print(limbMoveSpeed);
        transform.Rotate(Vector3.forward * (limbMoveSpeed * Time.deltaTime));
        currDropTime += timeTilDrop;
    }

    void PassiveDrop()
    {
        transform.Rotate(Vector3.back * (passiveDropSpeed * Time.deltaTime));
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