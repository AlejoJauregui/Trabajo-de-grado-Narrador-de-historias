using UnityEngine;
using System.Collections;

public class Pause_Game : MonoBehaviour 
{
	public KeyCode pauseGame;
	public GameObject pauseWindow;


	void Update()
	{
		checkPauseGame ();
	}
	//Checking the input
	public void checkPauseGame()
	{
		if (Input.GetKey (pauseGame)) 
		{
			PauseGame ();
		} 
	}
	//Pause the game method 
	public void PauseGame()
	{
		//When the game is in the playmode (FPS = 1)
		if(Time.timeScale == 1.0f)
		{
			Time.timeScale = 0;
			pauseWindow.SetActive (true);
		}
		else //Changing the the pause mode to the playmode
		{
			Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
			pauseWindow.SetActive (false);
		}
	}
}
