using UnityEngine;
using System.Collections;

public class BeginTheStoryCommand : StoryTellerCommand
{
	public BeginTheStoryCommand (StoryTeller reciver) : base (reciver)
	{

	}
	//Execute the method from receiver
	public override void Execute()
	{
		reciver.beginTheStory ();
	}
}
