using UnityEngine;

public class ANADemo : MonoBehaviour
{
	AudioSource unityAudio;
	int soundID;
	
	void Start()
	{
		unityAudio = GetComponent<AudioSource>();
		
		AndroidNativeAudio.makePool(1);
		soundID = AndroidNativeAudio.load("Android Native Audio/Tone Native.wav");
	}

	void OnGUI()
	{
		GUI.skin.button.fontSize = 32;
		
		if(GUI.Button(new Rect(20,40,680,100), "Unity Audio"))
		{
			unityAudio.Play();
		}

		if(GUI.Button(new Rect(20,640,680,100), "Native Audio"))
		{
			AndroidNativeAudio.play(soundID);
		}
	}
}
