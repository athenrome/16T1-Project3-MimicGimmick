using UnityEngine;
using System.Collections;

public class PlayerLimb : MonoBehaviour {

    public LimbPosition bodyPos;

    public float limbMoveSpeed = 5;
    public float passiveDropSpeed = 0.3f;

    float timeTilLock;
    float currLockTime;

    float timeTilDrop = 3;
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
        //CheckLimbPosition();
	
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
                Debug.Log("In position");
                currLockTime -= Time.deltaTime;
            }
        }

        if(currLockTime <= 0)
        {
            limbLocked = true;
        }
    }

    void MoveLimbUp()
    {

            //float oldZ = transform.rotation.z;
            //float newZ = oldZ += passiveDropSpeed * Time.deltaTime;

            //transform.Rotate(transform.rotation.x, transform.rotation.y, newZ);

            //Debug.Log("Moving Leg " + currLimbRotation);
            //currDropTime = timeTilDrop;

        transform.Rotate(Vector3.forward * (limbMoveSpeed * Time.deltaTime));

    }

    void PassiveDrop()
    {

            //float oldZ = transform.rotation.z;
            //float newZ = oldZ -= passiveDropSpeed * Time.deltaTime;

            //transform.Rotate(transform.rotation.x, transform.rotation.y, newZ);
            //Debug.Log("Dropping Leg");

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