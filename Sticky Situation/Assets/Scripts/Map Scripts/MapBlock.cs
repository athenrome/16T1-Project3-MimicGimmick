using UnityEngine;
using System.Collections;

public class MapBlock : MonoBehaviour {

    public int foodCount;
    public int mimicZoneCount;

    public BlockType type;

    public bool spawned;

	// Use this for initialization
	void Start () {
        spawned = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public enum BlockType
{
    Wall,

}
