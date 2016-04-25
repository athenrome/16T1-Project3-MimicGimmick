using UnityEngine;
using System.Collections.Generic;

public class GameMap : MonoBehaviour {

    List<MapBlock> tilesToPlace;

    public List<MapRow> mapRows;

    int rowCount;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameMap(int _desiredRows, List<MapBlock> availableTiles)
    {
        rowCount = _desiredRows;

        for(int currRow = 0; mapRows.Count < rowCount; currRow++)
        {

            int tilesToChoose = Random.Range(1, (tilesToPlace.Count / 2));


            List<MapBlock> newRowBlocks = new List<MapBlock>();


            for (int i = 0; i < tilesToChoose; i++)
            {
                int targetLocation = Random.Range(0, tilesToPlace.Count);

                MapBlock chosenBlock = tilesToPlace[targetLocation];

                newRowBlocks.Add(chosenBlock);

                tilesToPlace.Remove(chosenBlock);
            }

            mapRows.Add(new MapRow(currRow, newRowBlocks));

        }
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
    }

}
