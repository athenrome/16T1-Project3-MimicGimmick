using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text UIMimicLevel;
    public GameObject mimicUI;

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


        if(player.MimicMode == true)
        {
            mimicUI.SetActive(true);
            UIMimicLevel.text = "Current Mimic Level: " + player.mimicLevel;
        }
        else
        {
            mimicUI.SetActive(false);
        }
    }

    void UpdateLifeSlider()
    {
        lifebar.value = player.LifePoints -= (lifeLostPerSec * Time.deltaTime);
    }
}
