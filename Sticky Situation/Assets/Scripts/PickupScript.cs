using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    public float lifePointsValue = 15; 
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

            leaf.SetActive(false);
			leafEaten = true;
            timeTilRespawn = leafRespawnDuration;


			Debug.Log ("we ate a leaf");
			AudioSource.PlayClipAtPoint (eatingSound, this.transform.position);

        }
    }
}
