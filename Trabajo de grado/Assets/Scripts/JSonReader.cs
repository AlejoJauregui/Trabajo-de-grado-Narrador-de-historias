using UnityEngine;
using System.Collections;


public class JSonReader : MonoBehaviour
{
	public ArrayList Observers = new ArrayList ();
	//Emotion variables
	public double EmotionVal1 = 0.0d;
	public double EmotionVal2 = 0.0d;
	public double EmotionVal3 = 0.0d;
	public double EmotionVal4 = 0.0d;
	public double EmotionVal5 = 0.0d;
	public double EmotionVal6 = 0.0d;
	//Conclusion variable
	private string variableMood = "";
	//Transletor variable
	JSONObject FACEObject;
	//Answer
	public string jsonString; 

	//Constructor
	public JSonReader (string jsonString)
	{
		this.jsonString = jsonString;
		ReadFaceJSon (jsonString);
	}
	
	//Reading the aswer
	public void ReadFaceJSon(string JSonScript)
	{
		FACEObject = new JSONObject (JSonScript);
		for(int i= 0; i < FACEObject.list.Count; i++ )
		{
			string keyTmp =  FACEObject.keys[i];
			if(keyTmp.Equals("persons"))
			{
				JSONObject persons = FACEObject.list[i];
				Debug.Log("Esta es la lista de personas: " + persons);
				for(int j = 0; j < persons.list.Count; j++)
				{
					//Information lists…to access 
					JSONObject attributes = persons.list[j];
					JSONObject gender = attributes.list[0];
					JSONObject age = attributes.list[1];
					JSONObject expressions = attributes.list[2];
					//Get the mood and their values
					for(int h = 0; h < expressions.list.Count; h++)
					{
						JSONObject moodsJsonAnswer = expressions.list[h];
				
						//Moods
						if(h==0)
						{
							JSONObject sadness = moodsJsonAnswer.GetField("value");
							double sadValue = double.Parse(moodsJsonAnswer.GetField("value").ToString()); 
							EmotionVal1 = sadValue;
						}
						if(h==1)
						{
							JSONObject neutral = moodsJsonAnswer.GetField("value");
							double neutralValue = double.Parse(moodsJsonAnswer.GetField("value").ToString());
							EmotionVal2 = neutralValue;
						}
						if(h==2)
						{
							JSONObject disgust = moodsJsonAnswer.GetField("disgust");
							double disgustValue = double.Parse (moodsJsonAnswer.GetField("value").ToString());
							double EmotionValDisgust = disgustValue;
						}
						if(h==3)
						{

							JSONObject anger = moodsJsonAnswer.GetField("anger");
							double angerValue = double.Parse(moodsJsonAnswer.GetField("value").ToString());
							EmotionVal3 = angerValue;
						}
						if(h==4)
						{
							JSONObject surprise = moodsJsonAnswer.GetField("surprise");
							double surpriseValue = double.Parse(moodsJsonAnswer.GetField("value").ToString());
							EmotionVal4 = surpriseValue;
						}
						if(h==5)
						{
							JSONObject fear = moodsJsonAnswer.GetField("fear");
							double fearValue = double.Parse(moodsJsonAnswer.GetField("value").ToString());
							EmotionVal5 = fearValue;

						}
						if(h==6)
						{
							JSONObject happiness = moodsJsonAnswer.GetField("happiness");
							double happinessValue = double.Parse(moodsJsonAnswer.GetField("value").ToString());
							EmotionVal6 = happinessValue;
						}

					}
					ConclusionFramework(EmotionVal1,"Sad",EmotionVal2,"Neutral",EmotionVal3,"Anger",EmotionVal4,"Surprise",
					                    EmotionVal5,"Fear",EmotionVal6,"Happiness");
				}
			}
		}
		
	}
	//Conclusion Method
	public string ConclusionFramework(double EmoVal1, string EmotionName1, double EmoVal2, string EmotionName2, double EmoVal3, string EmotionName3, double EmoVal4, string EmotionName4, double EmoVal5, string EmotionName5, double EmoVal6, string EmotionName6)
	{
		double ValComparation = 0;
		string ConclutionMood = "Hey!!!";
		ArrayList MoodsNames = new ArrayList ();
		ArrayList MoodsVals = new ArrayList ();

		//MoodsVals Array fill
		MoodsVals.Add (EmoVal1);
		MoodsVals.Add (EmoVal2);
		MoodsVals.Add (EmoVal3);
		MoodsVals.Add (EmoVal4);
		MoodsVals.Add (EmoVal5);
		MoodsVals.Add (EmoVal6);

		//Moods Array Fill
		MoodsNames.Add (EmotionName1);
		MoodsNames.Add (EmotionName2);
		MoodsNames.Add (EmotionName3);
		MoodsNames.Add (EmotionName4);
		MoodsNames.Add (EmotionName5);
		MoodsNames.Add (EmotionName6);

		//Walking in the Arrays
		for (int i=0; i<=5; i++) 
		{
			if(((double)MoodsVals[i]) > ValComparation)
			{
				ValComparation = (double)MoodsVals[i];
				ConclutionMood = (string)MoodsNames[i];
			}
		}
		Debug.Log ("El niño está: " + ConclutionMood + " y el valor de comparación es: " + ValComparation);
		SetMoodConclusion (ConclutionMood);
		return ConclutionMood;
	}

	//Getter and setter tMood
	public string GetMoodConclusion ()
	{
		return variableMood;
	}
	public void SetMoodConclusion(string Mood)
	{
		this.variableMood = Mood;
	}
	
}