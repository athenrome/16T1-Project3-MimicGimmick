using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject cameraObj;
    public Transform moveCameraPos;
    public Transform mimicCameraPos;
    public Transform mimicPlayerPos;

    public float LifePoints;
	public Vector3 PlayerPosition;
	public float MoveSpeed;
	public float RotateSpeed;

    public bool inMimicZone;
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
	public Rigidbody rb;

    // Use this for initialization
    void Start () {
        inMimicZone = false;
        ModeSwitch(false);

		rb = GetComponent<Rigidbody> ();
       
	
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
            else
            {
                Debug.Log("Not avalable in current mode");
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

        if (Input.GetKey(KeyCode.D))
        {
            if (MimicMode == false)
            {
                RotatePlayerRight();
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) // interact key
        {
            if (inMimicZone == true)
            {
                if(MimicMode == false)
                {
                    ModeSwitch(true);
                }
                else
                {
                    ModeSwitch(false);
                }
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

    public void ModeSwitch(bool enableMimic)
    {
        print("Mode Switch");

        if(enableMimic == true)
        {
            print("In Mimic Mode");
            MimicMode = true;
            MimicModel.SetActive(true);
            MoveModel.SetActive(false);

            transform.position = mimicPlayerPos.transform.position;
            transform.rotation = mimicPlayerPos.transform.rotation;

            cameraObj.transform.position = mimicCameraPos.transform.position;
            cameraObj.transform.rotation = mimicCameraPos.transform.rotation;
        }
        else
        {
            print("In Move Mode");
            MimicMode = false;
            MimicModel.SetActive(false);
            MoveModel.SetActive(true);
            cameraObj.transform.position = moveCameraPos.transform.position;
            cameraObj.transform.rotation = moveCameraPos.transform.rotation;
        }
    }

	void MovePlayerForward ()
	{
        //transform.Translate(Vector3.forward * -MoveSpeed);
		rb.position += transform.rotation * -Vector3.forward * MoveSpeed * Time.deltaTime;
    }

    void MovePlayerBack()
    {
		//transform.Translate(Vector3.forward * MoveSpeed);
		rb.position += transform.rotation * Vector3.forward * MoveSpeed * Time.deltaTime;
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

     void OnCollisionEnter(Collision other)
      {
         if (other.gameObject.tag == "Pickup")
         {
            Debug.Log("Hello");
            Destroy(other.gameObject);
         }
    }
}
