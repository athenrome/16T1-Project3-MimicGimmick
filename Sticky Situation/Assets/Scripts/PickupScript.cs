using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

<<<<<<< HEAD
    float lifePointsValue = 15; 
=======
    public float lifePointsValue = 15; 
>>>>>>> parent of 30752cb... all of my changes, made to the bird, sapling, player, UI, and scenes. I think we might have something.
	public bool leafEaten;
	public GameObject leaf;
	public AudioClip eatingSound;

    public float leafRespawnDuration = 10;
    float timeTilRespawn;

	// Use this for initialization
	void Start () {
		leafEaten = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(leafEaten == true)
        {
            timeTilRespawn -= Time.deltaTime;

            if(timeTilRespawn <= 0)
            {
                leaf.SetActive(true);
                leafEaten = false;
                Debug.Log("respwaned leaf");
            }
        }

        
	
	}

    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.name == "Player" && leafEaten == false)
        {
            Player player = other.gameObject.GetComponent<Player>();

            player.LifePoints += lifePointsValue;
            if(player.LifePoints > 100)
            {
                player.LifePoints = 100;
            }

            leaf.SetActive(false);
			leafEaten = true;
            timeTilRespawn = leafRespawnDuration;


			Debug.Log ("we ate a leaf");
			AudioSource.PlayClipAtPoint (eatingSound, this.transform.position);

        }
    }
}
