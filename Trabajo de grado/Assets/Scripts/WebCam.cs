
using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour 
{

	public string WebCamName; 
	private WebCamTexture webCamVariable; //The variable that will save the texture  
	
	private string SavePhoto = "/Users/macbook/Documents/Unity Projects/TestTrabajo de grado/Assets/Snapshots/Snapshot";//The save Route
	public int CounterSnaps= 0; //Photo Sequence name to save 

	// Use this for initialization
	void Start () 
	{
		VerifyWebCam ();
		TurnOnCamera ();
	}

	//Methods
	//Checking if the laptop or desktop has a Web Cam connected 
	void VerifyWebCam()
	{
		WebCamDevice[] devices = WebCamTexture.devices;
		
		for (int i = 0; i < devices.Length; i++) 
		{
			Debug.Log (devices [i].name);
			WebCamName = devices [i].name;
		}
	}

	//Turn On The camera
	void TurnOnCamera ()
	{
		WebCamTexture webCamTexture = new WebCamTexture ();
		webCamTexture.Play ();
		Debug.Log (webCamTexture.isPlaying);
		
		webCamVariable = webCamTexture;
	}
	//Taking the photo and saving that photo
	public void TakeSnapshot()
	{
			//Taking snaps
			Texture2D snap = new Texture2D (webCamVariable.width, webCamVariable.height);
			snap.SetPixels (webCamVariable.GetPixels ());
			snap.Apply ();
			Debug.Log ("Taking a snap");
			
			//Saving Snaps
			System.IO.File.WriteAllBytes (SavePhoto + CounterSnaps.ToString () + ".jpg", snap.EncodeToJPG ());
			++CounterSnaps;
			Debug.Log ("Saving the snap");
	}
	
}