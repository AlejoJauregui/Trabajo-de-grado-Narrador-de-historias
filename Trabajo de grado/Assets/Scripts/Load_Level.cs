using UnityEngine;
using System.Collections;

public class Load_Level : MonoBehaviour 
{
	public AudioSource backgroundSound;
	public void OnPressedButton() 
	{
		backgroundSound.mute = true;
		Application.LoadLevel("Loading_Scene");
	}
}
