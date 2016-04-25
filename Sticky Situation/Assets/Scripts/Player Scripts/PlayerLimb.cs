using UnityEngine;
using System.Collections;

public class PlayerLimb : MonoBehaviour {

    public LimbPosition bodyPos;

    public float limbRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public enum LimbMode
{
    Locked,
    Mimic,
    Moving,
}

public enum LimbPosition
{
    UpperRight,
    UpperLeft,
    LowerRight,
    LowerLeft,
}