using UnityEngine;
using System.Collections;

public class AudioLibrary : MonoBehaviour 
{
	//Audios Variables
	public AudioSource startStory;

	public AudioSource happyFragmentStory1;
	public AudioSource happFragmentStory2;
	public AudioSource happFragmentStory3;

	public AudioSource sadFragmentStory1;
	public AudioSource sadFragmentStory2;
	public AudioSource sadFragmentStory3;

	public AudioSource angryFragmentStory1;
	public AudioSource angryFragmentStory2;
	public AudioSource angryFragmentStory3;
	

	public ArrayList happyStories = new ArrayList ();
	public ArrayList sadStories = new ArrayList ();
	public ArrayList angryStories = new ArrayList ();
			

	// Use this for initialization: Adding the audios to the ArrayLists
	void Awake () 
	{
		AddHappyFragments ();	
		AddSadFragments ();
		AddAngryStories ();

	}

	//Adding Happy fragments audios 
	public void AddHappyFragments()
	{
		happyStories.Add (happyFragmentStory1);
		happyStories.Add (happFragmentStory2);
		happyStories.Add (happFragmentStory3);
	}
	//Adding Sad fragments audios
	public void AddSadFragments()
	{
		sadStories.Add (sadFragmentStory1);
		sadStories.Add (sadFragmentStory2);
		sadStories.Add (sadFragmentStory3);
	}
	//Adding Angry fragments audios 
	public void AddAngryStories ()
	{
		angryStories.Add (angryFragmentStory1);
		angryStories.Add (angryFragmentStory2);
		angryStories.Add (angryFragmentStory3);
	}
	//Getters
	public ArrayList getHappyArrayList()
	{
		return happyStories;
	}
	public ArrayList getSadArrayList()
	{
		return sadStories;
	}
	public ArrayList getAngryArrayList()
	{
		return angryStories;
	}
	public AudioSource getStartAudio()
	{
		return startStory;
	}
}
