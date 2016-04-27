using UnityEngine;
using System.Collections;

public class ChooseSadStoryCommand : StoryTellerCommand
{
	public ChooseSadStoryCommand (StoryTeller reciver) : base (reciver)
	{

	}
	//Execute the method from receiver
	public override void Execute()
	{
		reciver.ChooseSadStory ();
	}
}
