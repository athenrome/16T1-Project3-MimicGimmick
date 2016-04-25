using UnityEngine;
using System.Collections.Generic;

public class MapDrawer : MonoBehaviour {

    GameMap map;

    public float drawX;
    public float drawY;


	// Use this for initialization
	void Start () {
        DrawMap();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DrawMap()
    {
        for (int i = 0; i < map.mapRows.Count; i++)
        {
            DrawRow(map.mapRows[i]);
            NextRowLocation();
        }
    }

    void DrawRow(MapRow drawRow)
    {
        drawX = 0; 
        transform.position = new Vector3(drawX, drawY);//restes the drawer to start x

        foreach(MapBlock drawBlock in drawRow.rowBlocks)
        {
            GameObject.Instantiate(drawBlock, this.transform.position, this.transform.rotation);
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
