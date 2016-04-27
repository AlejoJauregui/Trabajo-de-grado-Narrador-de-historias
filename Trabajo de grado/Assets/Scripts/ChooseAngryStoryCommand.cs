using UnityEngine;
using System.Collections;

public class ChooseAngryStoryCommand : StoryTellerCommand 
{

	public ChooseAngryStoryCommand (StoryTeller reciver) : base(reciver)
	{

	}
	//Execute the method from receiver
	public override void Execute()
	{
		reciver.ChooseAngryStory ();                        
	}
	
}
