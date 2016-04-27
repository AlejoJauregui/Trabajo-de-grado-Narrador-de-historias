using UnityEngine;
using System.Collections;

public class ChooseHappyStoryCommand : StoryTellerCommand 
{
	public ChooseHappyStoryCommand (StoryTeller reciver) : base (reciver)
	{

	}
	//Execute the method from receiver
	public override void Execute()
	{
		reciver.ChooseHappyStory ();
	}
}
