using UnityEngine;
using System.Collections;

public class StoryTellerCommand : Command 
{

	protected StoryTeller reciver;
	//Identify the receiver
	public StoryTellerCommand (StoryTeller reciver)
	{
		this.reciver = reciver;
	}
}
