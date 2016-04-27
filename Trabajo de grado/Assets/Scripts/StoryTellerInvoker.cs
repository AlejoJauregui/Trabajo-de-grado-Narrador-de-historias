using UnityEngine;
using System.Collections;

public class StoryTellerInvoker : MonoBehaviour 
{
	public StoryTeller reciver; //Reference to the receiver
	public string currentMood; //Mood answer
	private int trafficLight;
	

	// Use this for initialization
	void Awake()
	{
		currentMood = "The mood isn't arrive yet";
	}
	
	// Update is called once per frame 
	void Update ()
	{
		CheckInput ();
	}

	//Verification method: The Mood is here
	public void CheckInput()
	{
		Debug.Log ("current mood tiene: " + currentMood);

		if(currentMood == "The mood isn't arrive yet")
		{
				InvokeStartTheStory();
		}

		if (currentMood == "Sad") 
		{
			if(TrafficLights.stopCommand == 0)
			{
				InvokeChooseHappyStory();
			}
			Debug.Log ("Y el sentimiento es… " + currentMood);
		}
		if (currentMood == "Neutral") 
		{
			if(TrafficLights.stopCommand == 0)
			{
				InvokeChooseAngryStory();
			}
			Debug.Log ("Y el sentimiento es… " + currentMood);
		}	
		if (currentMood == "Anger") 
		{
			if(TrafficLights.stopCommand == 0)
			{
				InvokeChooseSadStory();
			}
			Debug.Log ("Y el sentimiento es… " + currentMood);
		}
		if (currentMood == "Surprise") 
		{
			if(TrafficLights.stopCommand == 0)
			{
				InvokeChooseSadStory();
			}
			Debug.Log ("Y el sentimiento es… " + currentMood);
		}
		if (currentMood == "Fear") 
		{
			if(TrafficLights.stopCommand == 0)
			{
				InvokeChooseHappyStory();
			}
			Debug.Log ("Y el sentimiento es… " + currentMood);
		}
		if (currentMood == "Happiness") 
		{
			if(TrafficLights.stopCommand == 0)
			{
				InvokeChooseAngryStory();
			}
			Debug.Log ("Y el sentimiento es… " + currentMood);
		}

	}
	//Getters and setters
	public void setMood(string mood)
	{
		this.currentMood = mood;
	}
	public string getMood()
	{
		return currentMood;
	}
	public void setTrafficLight (int trafficLight)
	{
		this.trafficLight = trafficLight;
	}

	//Invokes methods from the receiver
	public void InvokeStartTheStory()
	{
		BeginTheStoryCommand startStoryCommand = new BeginTheStoryCommand (reciver);
		startStoryCommand.Execute ();
	}
	public void InvokeChooseSadStory()
	{
		ChooseSadStoryCommand commandChooseSadWay = new ChooseSadStoryCommand (reciver);
		commandChooseSadWay.Execute ();
	}
	public void InvokeChooseHappyStory()
	{
		ChooseHappyStoryCommand commandChooseHappyWay = new ChooseHappyStoryCommand (reciver);
		commandChooseHappyWay.Execute ();
	}
	public void InvokeChooseAngryStory()
	{
		ChooseAngryStoryCommand commandChooseAngryWay = new ChooseAngryStoryCommand(reciver);
		commandChooseAngryWay.Execute ();
	}

}
