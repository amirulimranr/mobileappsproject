using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ScrambledWordGame.Types
{

	public class SWGToggleSound : MonoBehaviour
	{
		public string soundObjectTag = "Sound";
		
		public Transform soundObject;
		
		public string playerPref = "SoundVolume";
		
		internal float currentState = 1;

		[Tooltip("The volume when this sound button is toggled on")]
		public float volumeOn = 1;

		[Tooltip("The volume when this sound button is toggled off")]
		public float volumeOff = 0;
		

		void Awake()
		{
			if ( !soundObject && soundObjectTag != string.Empty )    soundObject = GameObject.FindGameObjectWithTag(soundObjectTag).transform;
			
			if( soundObject )
				currentState = PlayerPrefs.GetFloat(playerPref, soundObject.GetComponent<AudioSource>().volume);
			else   
				currentState = PlayerPrefs.GetFloat(playerPref, currentState);
			

			SetSound();
		}

        public void SetSound()
		{
			if ( !soundObject && soundObjectTag != string.Empty )    soundObject = GameObject.FindGameObjectWithTag(soundObjectTag).transform;
			
			PlayerPrefs.SetFloat(playerPref, currentState);
			
			Color newColor = GetComponent<Image>().material.color;
			
			if( currentState == volumeOn )
				newColor.a = 1;
			else
				newColor.a = 0.5f;
			
			GetComponent<Image>().color = newColor;
			
			if( soundObject ) 
				soundObject.GetComponent<AudioSource>().volume = currentState;
		}
		
		public void ToggleSound()
		{
			if( currentState == volumeOn )    currentState = volumeOff;
			else    currentState = volumeOn;
			
			SetSound();
		}

        public void StartSound()
		{
			if( soundObject )
				soundObject.GetComponent<AudioSource>().Play();
		}
	}
}