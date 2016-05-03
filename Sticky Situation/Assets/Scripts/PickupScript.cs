using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    public float lifePointsValue; 
	public bool leafEaten;
	public GameObject leaf;
	public AudioClip eatingSound;
	// Use this for initialization
	void Start () {
		leafEaten = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.name == "Player" && leafEaten == false)
        {
            Player player = other.gameObject.GetComponent<Player>();

            player.LifePoints += lifePointsValue;

			Destroy(leaf);
			leafEaten = true;
			Debug.Log ("we ate a leaf");
			AudioSource.PlayClipAtPoint (eatingSound, this.transform.position);

        }
    }
}
