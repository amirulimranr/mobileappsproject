using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ScrambledWordGame
{

	public class SWGPlaySound : MonoBehaviour
	{
		[Tooltip("The sound to play")]
		public AudioClip sound;

		[Tooltip("Should we play the sound when the game starts")]
		public bool playOnStart = false;

        [Tooltip("Should we play the sound when clicking this button?")]
        public bool playOnClick = true;

        [Tooltip("The tag of the sound source")]
		public string soundSourceTag = "Sound";

        void Start()
        {
            
            if ( GetComponent<Button>() ) GetComponent<Button>().onClick.AddListener(delegate { PlaySound(); });
        }

        void OnEnable()
        {
			if( playOnStart == true )    PlaySound();
		}

		public void PlaySound()
		{
			
			if ( soundSourceTag != string.Empty && sound ) 
			{
			
				GameObject.FindGameObjectWithTag(soundSourceTag).GetComponent<AudioSource>().PlayOneShot(sound);
			}	
		}
	}
}