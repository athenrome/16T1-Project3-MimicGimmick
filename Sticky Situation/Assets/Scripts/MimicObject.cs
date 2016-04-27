using UnityEngine;
using System.Collections;

public class MimicObject : MonoBehaviour {

    public float UpperLeftPosition;
    public float UpperRightPosition;
    public float LowerLeftPosition;
    public float LowerRightPosition;

    public GameObject UpperLeft;
    public GameObject UpperRight;
    public GameObject LowerLeft;
    public GameObject LowerRight;


    // Use this for initialization
    void Start () {
        SetLimbPositions();
        FacePlayer();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FacePlayer()
    {

    }

    void SetLimbPositions()
    {
        UpperLeft.transform.rotation = new Quaternion(UpperLeft.transform.rotation.x, UpperLeft.transform.rotation.y, UpperLeftPosition, 0);
        UpperRight.transform.rotation = new Quaternion(UpperRight.transform.rotation.x, UpperRight.transform.rotation.y, UpperRightPosition, 0);
        LowerLeft.transform.rotation = new Quaternion(LowerLeft.transform.rotation.x, LowerLeft.transform.rotation.y, LowerLeftPosition, 0);
        LowerRight.transform.rotation = new Quaternion(LowerRight.transform.rotation.x, LowerRight.transform.rotation.y, LowerRightPosition, 0);
    }
}
