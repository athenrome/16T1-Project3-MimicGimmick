using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public Player player;


    // Use this for initialization
    void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void CheckGame()
    {
        if(player.LifePoints <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Debug.Log("End Game");
    }
}
