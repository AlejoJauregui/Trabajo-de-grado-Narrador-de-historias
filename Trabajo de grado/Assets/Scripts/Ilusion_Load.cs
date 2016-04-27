using UnityEngine;
using System.Collections;

public class Ilusion_Load : MonoBehaviour 
{
	public AudioSource BattleSound;
	public void OnPressedButton()
	{
		BattleSound.mute = true;
		Application.LoadLevel ("Wisdom_City");
	}
}
