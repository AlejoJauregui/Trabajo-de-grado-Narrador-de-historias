using UnityEngine;
using System.Collections;



public class WebServiceConnection : MonoBehaviour 
{

	private JSonReader jSonReader; //Variable to save the web service answer
	public GameObject storyTellerInvoker; // Invoker Reference 

	public string URL; //Web service URL
	private string client_Id = "c89b1df60446439581b4b03fb8030967";//"f6c0d17dce804e9e8ca198b420e4cd7d"; //Web Service User Identification
	private string app_Key = "31c0808077d04f8383b8039b648a5b08";//"a0480811ed484f3e82565715ac8ceeae"; //Web Service app identification
	private int CounterSnaps= 0; //Photo Sequence name to read
	private string PhotoLocation = "/Users/macbook/Documents/Unity Projects/TestTrabajo de grado/Assets/Snapshots/snapshot"; //Route where the photos would be located
	public string Mood = "No";
	

	// Use this for initialization
	void Start()
	{
		string currentURL = PhotoLocation + CounterSnaps + ".jpg";
		MakeFaceRequest (currentURL);
	}

	//Wating for a request 
	IEnumerator WaitForRequest (WWW URLConnection, WWWForm FaceForm) 
	{
		yield return new WaitForSeconds (5);
		yield return URLConnection;
		yield return FaceForm;
		//Exception to control the web service connection
		if(URLConnection.error == null)
		{
			Debug.Log (URLConnection.text);
			Debug.Log ("The Connection would be in a few seconds…" + URLConnection.progress);
			Debug.Log ("Succesful Connection");

			//Flags for watch the expected beahavior
			jSonReader = new JSonReader (URLConnection.text);
			Debug.Log ("Tengo esto: " + jSonReader.jsonString);
			Debug.Log ("Triste es igual a… " + jSonReader.EmotionVal1);
			Debug.Log ("Neutral es igual a… " + jSonReader.EmotionVal2);
			Debug.Log ("Enojado es igual a… " + jSonReader.EmotionVal3);
			Debug.Log ("Sorprendido es igual a… " + jSonReader.EmotionVal4);
			Debug.Log ("Miedo es igual a… " + jSonReader.EmotionVal5);
			Debug.Log ("Felicidad es igual a… " + jSonReader.EmotionVal6);
			//Getting the conclusion and setting the mood 
			Mood = jSonReader.GetMoodConclusion();
			setMood(Mood);
			//Sending the mood to the invoker
			storyTellerInvoker.GetComponent<StoryTellerInvoker>().setMood(Mood);
			//The powerful trafficlights
			TrafficLights.stopAndPlay = 0;
			TrafficLights.stopCommand = 0;
			Debug.Log ("la variable de storyTellerInvoker tiene: " + storyTellerInvoker.GetComponent<StoryTellerInvoker>().getMood());
		}
		else
		{
			//Message error: When the Web service couldn't connect
			Debug.Log("Whoops!!! There was a little problem: " + URLConnection.error);
		}
		//Reading photos
		CounterSnaps++;
		string currentURL = PhotoLocation + CounterSnaps + ".jpg";
		MakeFaceRequest (currentURL);
	}

	//Making the request
	public void MakeFaceRequest(string PhotoLocation)
	{
		Debug.Log ("Logré llegar desde el storyTeller");
		//Filling the form
		WWWForm FaceForm = new WWWForm ();
		FaceForm.AddField ("client_id",client_Id);
		FaceForm.AddField ("app_key", app_Key);
		FaceForm.AddField ("attribute", "age, gender, expressions");
		FaceForm.AddBinaryData ("img", System.IO.File.ReadAllBytes(PhotoLocation), "snapshot0.jpg","multipart/Form-data");
		
		//Preparing the answer
		WWW URLConnection = new WWW (URL,FaceForm);
		StartCoroutine (WaitForRequest (URLConnection, FaceForm));
	}
	//Active The connection
	public void ExecuteMakeFaceRequest(string choice)
	{
		if (choice == "yes") 
		{
			string currentURL = PhotoLocation + CounterSnaps + ".jpg";
			Debug.Log(currentURL);
			MakeFaceRequest (currentURL);
		}
	}
	//Getters and setters
	public void setMood(string mood)
	{
		this.Mood = mood;
	}
	public string getMood()
	{
		return Mood;
	}

	
}