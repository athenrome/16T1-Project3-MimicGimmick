using UnityEngine;
using System.Collections.Generic;

public class MapDrawer : MonoBehaviour {

    public List<MapBlock> mapBlocks;

    GameMap map;

    public float drawX;
    public float drawY;


	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DrawMap()
    {
        Debug.Log("Started map drawing");
        map = new GameMap(mapBlocks);

        for (int i = 0; i < map.mapRows.Count; i++)
        {
            DrawRow(map.mapRows[i]);
            NextRowLocation();
            Debug.Log("Drew Row");
        }
        Debug.Log("Drew Map");
    }

    void DrawRow(MapRow drawRow)
    {
        drawX = 0; 
        transform.position = new Vector3(drawX, drawY);//restes the drawer to start x

        foreach(MapBlock drawBlock in drawRow.rowBlocks)
        {
            GameObject.Instantiate(drawBlock, this.transform.position, this.transform.rotation);
            drawBlock.spawned = true;
            NextBlockLocation();
        }
    }

    void NextBlockLocation()
    {
        drawX++;
        print(drawX);

        transform.position = new Vector3(drawX, drawY);
    }

    void NextRowLocation()
    {
        drawY++;
        transform.position = new Vector3(drawX, drawY);
    }

}
