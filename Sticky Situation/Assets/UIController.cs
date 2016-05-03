using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Slider lifebar;
    float lifeLostPerSec = 3;

    public Player player;

	// Use this for initialization
	void Start () {
        lifebar.value = player.LifePoints;
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateLifeSlider();

    }

    void UpdateLifeSlider()
    {
        lifebar.value = player.LifePoints -= (lifeLostPerSec * Time.deltaTime);
    }
}
