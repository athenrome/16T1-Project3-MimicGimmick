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

    public float minPos = 5;
    public float maxPos = 175;


    // Use this for initialization
    void Start () {
        ChooseLimbPositions();
        SetLimbPositions();
        FacePlayer();
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FacePlayer()
    {

    }

    void ChooseLimbPositions()
    {
        UpperLeftPosition = Random.Range(-minPos, -maxPos);
        UpperRightPosition = Random.Range(minPos, maxPos);
        LowerLeftPosition = Random.Range(-minPos, -maxPos);
        LowerRightPosition = Random.Range(minPos, maxPos);
        Debug.Log(UpperLeftPosition);
    }

    void SetLimbPositions()
    {
        UpperLeft.transform.Rotate(0, 0, UpperLeftPosition);
        UpperRight.transform.Rotate(0, 0, UpperRightPosition);
        LowerLeft.transform.Rotate(0, 0, LowerLeftPosition);
        LowerRight.transform.Rotate(0, 0, LowerRightPosition);

        Debug.Log("Set Mimic limb positions");
    }
}
