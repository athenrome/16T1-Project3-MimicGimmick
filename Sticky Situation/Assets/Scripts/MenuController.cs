using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick_Play()
	{
		SceneManager.LoadScene (Scenes.Main);//Test Scene only for internal playtest

	}
	
	public void OnClick_Quit()
	{
		Application.Quit();
	}

	public void OnClick_Restart()
	{
		SceneManager.LoadScene (Scenes.TestScene);//Test Scene only for internal playtest
		Cursor.visible = false;
	}

	public void OnClick_About()
	{
		SceneManager.LoadScene (Scenes.about);
	}
		
}
	