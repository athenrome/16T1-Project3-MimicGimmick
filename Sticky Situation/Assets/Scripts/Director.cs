using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public MapDrawer mapDrawer;

	// Use this for initialization
	void Start () {
        mapDrawer.DrawMap();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
