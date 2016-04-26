using UnityEngine;
using System.Collections.Generic;

public class GameMap : MonoBehaviour {



    public List<MapRow> mapRows = new List<MapRow>();

    int desiredRows;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameMap(List<MapBlock> availableTiles)
    {
        

        for(int currRow = 0; currRow < desiredRows; currRow++)
        {

            int tilesToChoose = Random.Range(0, (availableTiles.Count));


            List<MapBlock> newRowBlocks = new List<MapBlock>();


            for (int i = 0; i < tilesToChoose; i++)
            {
                int targetLocation = Random.Range(0, availableTiles.Count);

                MapBlock chosenBlock = availableTiles[targetLocation];

                newRowBlocks.Add(chosenBlock);

                availableTiles.Remove(chosenBlock);
            }

            mapRows.Add(new MapRow(currRow, newRowBlocks));


        }
        Debug.Log("Created Game Map");
    }

    
}

public class MapRow
{
    public int rowPos;
    
    public List<MapBlock> rowBlocks;

    public MapRow(int _mapPos, List<MapBlock> _rowTiles)
    {
        rowPos = _mapPos;
        rowBlocks = _rowTiles;
        Debug.Log("Created MapRow");
    }

}
