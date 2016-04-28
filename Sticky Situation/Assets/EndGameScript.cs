using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

	[Tooltip("this is the first scene that we want to load, the main menu")]
	public string SceneToReload;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TryAgain ()
	{
		Debug.Log ("we are loading :" + SceneToReload);
		Application.LoadLevel (SceneToReload);

	}

	public void Quitting ()
	{
		Debug.Log ("we are Quitting" );
		//Application.Quit ();

	}

}
