using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    public float lifePointsValue; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();

            player.LifePoints += lifePointsValue;

            Destroy(this.gameObject);
        }
    }
}
