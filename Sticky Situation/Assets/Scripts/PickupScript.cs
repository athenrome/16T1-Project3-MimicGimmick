using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

	private float lifePointsValue = 15; 
	private bool leafEaten = false;
	public GameObject leaf;
	public AudioClip eatingSound;

	private float leafRespawnDuration = 25;
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
			Debug.Log (lifePointsValue);
            player.LifePoints += lifePointsValue;

            leaf.SetActive(false);
			leafEaten = true;
            timeTilRespawn = leafRespawnDuration;



			AudioSource.PlayClipAtPoint (eatingSound, this.transform.position);

        }
    }
}
