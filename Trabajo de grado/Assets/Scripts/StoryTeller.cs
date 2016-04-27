using UnityEngine;
using System.Collections;

public class StoryTeller : MonoBehaviour 
{
	//Audio Time variables
	private float currentAudioTime = 0.0f;
	private float audioTime = 0.0f;
	private int storyPicker = 0;

	//Send the notification permission
	private string choice = "yes";

	//Fragments audio ArrayLists
	private ArrayList sadStories = new ArrayList ();
	private ArrayList happyStories = new ArrayList ();
	private ArrayList angryStories = new ArrayList ();
	public ArrayList Observers = new ArrayList();

	//References to the objects

	public GameObject audioLibrary;
	public GameObject webCam;
	public GameObject webService;
	public GameObject Invoker;

	public GameObject onceUponATime;

	public GameObject sadStory1;
	public GameObject sadStory2;
	public GameObject sadStory3;

	public GameObject happyStory1;
	public GameObject happyStory2;
	public GameObject happyStory3;

	public GameObject angryStory1;
	public GameObject angryStory2;
	public GameObject angryStory3;

	public GameObject endTheStory;

	//TrafficLights
	private int stopAndPlay; 
	private bool active = false; 
 	
	//The player audios
	private AudioSource tellTheFragment;



	// Use this for initialization
	void Start () 
	{
		sadStories = audioLibrary.GetComponent<AudioLibrary>().sadStories;
		happyStories = audioLibrary.GetComponent<AudioLibrary>().happyStories;
		angryStories = audioLibrary.GetComponent<AudioLibrary>().angryStories;
	}

	//Start story method
	public void beginTheStory()
	{
		if (TrafficLights.stopAndPlay == 0)
		{
			tellTheFragment = audioLibrary.GetComponent<AudioLibrary>().startStory;
			onceUponATime.SetActive (true);
			tellTheFragment.Play ();
			TrafficLights.stopAndPlay = 1;
			Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(stopAndPlay);
		}
		currentAudioTime = tellTheFragment.time;
		audioTime = tellTheFragment.clip.length;
		if(currentAudioTime >= (audioTime - 2) && active == false)
		{
			Debug.Log ("Entre a tomar la foto");
			active = true;
			webCam.GetComponent<WebCam>().TakeSnapshot();
			Debug.Log ("Antes del notify");
			NotifyPhotoTakeIt();
			if(currentAudioTime >= (audioTime-1))
				tellTheFragment.Stop();
		}
		if (!tellTheFragment.isPlaying) 
		{
			Debug.Log ("Voy a desactivar el gameobject");
			onceUponATime.SetActive(false);
		}
	}
	//Chooser method: Sad stories
	public void ChooseSadStory()
	{
		if(storyPicker == 0)
		{
			Debug.Log ("SadStories activado!!!");
			Debug.Log ("staticClass es: " + TrafficLights.stopAndPlay);
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				tellTheFragment = ((AudioSource)sadStories[storyPicker]);
				sadStory1.SetActive(true);
				tellTheFragment.Play();
				Debug.Log ("stop and play" + TrafficLights.stopAndPlay);
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
				active = false;
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			Debug.Log ("estoy por entrar al if " + (currentAudioTime >= (audioTime-5)));
			Debug.Log ("El active esta en: " + active);
			if(currentAudioTime >= (audioTime - 5) && active == false)
			{
				Debug.Log ("Entre al metodo de los audios");
				storyPicker++;
				TrafficLights.stopCommand = 1;
				active = true;
				webCam.GetComponent<WebCam>().TakeSnapshot();
				NotifyPhotoTakeIt();
				TrafficLights.stopAndPlay = 0;
				if(currentAudioTime >= (audioTime-1))
					tellTheFragment.Stop();
			}
			if (!tellTheFragment.isPlaying) 
			{
				Debug.Log ("Voy a desactivar el gameobject");
				sadStory1.SetActive(false);
			}
		}
		else if (storyPicker == 1) 
		{
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				tellTheFragment = ((AudioSource)sadStories[storyPicker]);
				sadStory2.SetActive(true);
				tellTheFragment.Play();
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
				active = false;
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			if(currentAudioTime >= (audioTime - 5) && active == false)
			{
				storyPicker++;
				TrafficLights.stopCommand = 1;
				active = true;
				webCam.GetComponent<WebCam>().TakeSnapshot();
				NotifyPhotoTakeIt();
				TrafficLights.stopAndPlay = 0;
				if(currentAudioTime >= (audioTime-1))
					tellTheFragment.Stop();
			}
			if (!tellTheFragment.isPlaying) 
			{
				Debug.Log ("Voy a desactivar el gameobject");
				sadStory2.SetActive(false);
			}
		}
		else if (storyPicker == 2) 
		{
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				tellTheFragment = ((AudioSource)sadStories[storyPicker]);
				sadStory3.SetActive(true);
				tellTheFragment.Play();
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
				active = false;
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			if(currentAudioTime >= (audioTime -1) ) 
			{
				TrafficLights.stopCommand = 1;
				tellTheFragment.Stop();
				TrafficLights.stopAndPlay = 0;
				Application.LoadLevel("Credits_Scene");
				
			}
		}
		return;
	}
	//Chooser method: Happy stories
	public void ChooseHappyStory()
	{

		if(storyPicker == 0)
		{
			Debug.Log ("HappyStories activado");
			Debug.Log ("staticClass es: " + TrafficLights.stopAndPlay);
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				tellTheFragment = ((AudioSource)happyStories[storyPicker]);
				happyStory1.SetActive(true);
				tellTheFragment.Play();
				Debug.Log ("stop and play" + TrafficLights.stopAndPlay);
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
				active = false;
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			Debug.Log ("estoy por entrar al if currenttime " + currentAudioTime);
			Debug.Log ("El audiotime esta en: " + audioTime);
			if(currentAudioTime >= (audioTime - 5) && active == false)
			{
				Debug.Log ("Entre al metodo de los audios");
				storyPicker++;
				TrafficLights.stopCommand = 1;
				active = true;
				webCam.GetComponent<WebCam>().TakeSnapshot();
				NotifyPhotoTakeIt();
				TrafficLights.stopAndPlay = 0;
				if(currentAudioTime >= (audioTime-1))
					tellTheFragment.Stop();
			}
			if (!tellTheFragment.isPlaying) 
			{
				Debug.Log ("Voy a desactivar el gameobject");
				happyStory1.SetActive(false);
			}
		}
		else if (storyPicker == 1)
		{
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				tellTheFragment = ((AudioSource)happyStories[storyPicker]);
				happyStory2.SetActive(true);
				tellTheFragment.Play();
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
				active = false;
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			if(currentAudioTime >= (audioTime - 5) && active == false)
			{
				storyPicker++;
				TrafficLights.stopCommand = 1;
				active = true;
				webCam.GetComponent<WebCam>().TakeSnapshot();
				NotifyPhotoTakeIt();
				TrafficLights.stopAndPlay = 0;
				if(currentAudioTime >= (audioTime-1))
					tellTheFragment.Stop();
			}
			if (!tellTheFragment.isPlaying) 
			{
				Debug.Log ("Voy a desactivar el gameobject");
				happyStory2.SetActive(false);
			}
		}
		else if (storyPicker == 2) 
		{
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				tellTheFragment = ((AudioSource)happyStories[storyPicker]);
				happyStory3.SetActive(true);
				tellTheFragment.Play();
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
				active = false;
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			if(currentAudioTime >= (audioTime -1) ) 
			{
				TrafficLights.stopCommand = 1;
				tellTheFragment.Stop();
				TrafficLights.stopAndPlay = 0;
				Application.LoadLevel("Credits_Scene");
				
			}
		}
		return;
	}
	//Chooser method: Angry Stories
	public void ChooseAngryStory()
	{
		if(storyPicker == 0)
		{
			Debug.Log ("AngryStories activado!!!");
			Debug.Log ("staticClass es: " + TrafficLights.stopAndPlay);
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				Debug.Log ("Entre al metodo de los audios");
				tellTheFragment = ((AudioSource)angryStories[storyPicker]);
				angryStory1.SetActive(true);
				tellTheFragment.Play();
				Debug.Log ("stop and play" + TrafficLights.stopAndPlay);
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
				active = false;
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			Debug.Log ("estoy por entrar al if " + (currentAudioTime >= (audioTime-5)));
			Debug.Log ("El active esta en: " + active);
			if(currentAudioTime >= (audioTime - 5) && active == false)
			{
				Debug.Log ("Entre a lo del current ");
				storyPicker++;
				TrafficLights.stopCommand = 1;
				active = true;
				webCam.GetComponent<WebCam>().TakeSnapshot();
				NotifyPhotoTakeIt();
				TrafficLights.stopAndPlay = 0;
				if(currentAudioTime >= (audioTime-1))
					tellTheFragment.Stop();
			}
			if (!tellTheFragment.isPlaying) 
			{
				Debug.Log ("Voy a desactivar el gameobject");
				angryStory1.SetActive(false);
			}
		}
		else if(storyPicker == 1)
		{
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				tellTheFragment = ((AudioSource)angryStories[storyPicker]);
				angryStory2.SetActive(true);
				tellTheFragment.Play();
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			if(currentAudioTime >= (audioTime - 5) && active == false)
			{
				storyPicker++;
				TrafficLights.stopCommand = 1;
				active = true;
				webCam.GetComponent<WebCam>().TakeSnapshot();
				NotifyPhotoTakeIt();
				TrafficLights.stopAndPlay = 0;
				if(currentAudioTime >= (audioTime-1))
					tellTheFragment.Stop();
			}
			if (!tellTheFragment.isPlaying) 
			{
				Debug.Log ("Voy a desactivar el gameobject");
				angryStory2.SetActive(false);
			}
		}
		else if(storyPicker == 2)
		{
			if(TrafficLights.stopAndPlay == 0)
			{
				TrafficLights.stopAndPlay = 1;
				tellTheFragment = ((AudioSource)angryStories[storyPicker]);
				angryStory3.SetActive(true);
				tellTheFragment.Play();
				Invoker.GetComponent<StoryTellerInvoker>().setTrafficLight(TrafficLights.stopAndPlay);
				active = false; 
			}
			currentAudioTime = tellTheFragment.time;
			audioTime = tellTheFragment.clip.length;
			if(currentAudioTime >= (audioTime -1) ) 
			{
				TrafficLights.stopCommand = 1;
				tellTheFragment.Stop();
				TrafficLights.stopAndPlay = 0;
				Application.LoadLevel("Credits_Scene");

			}

		}
		return;
	}
	//Getter
	public AudioSource getTellTheFragment()
	{
		return tellTheFragment;
	}
	//Notify Method: Web Service activation Permission
	public void NotifyPhotoTakeIt ()
	{
		Debug.Log ("Llegue a notificar");
		webService.GetComponent<WebServiceConnection> ().ExecuteMakeFaceRequest (choice);

	}
	public void AttachedObserver(WebServiceConnection observer)
	{
		Observers.Add (observer);
	}
	public void RemoveObserver(WebServiceConnection observer)
	{
		Observers.Remove (observer);
	}
}
