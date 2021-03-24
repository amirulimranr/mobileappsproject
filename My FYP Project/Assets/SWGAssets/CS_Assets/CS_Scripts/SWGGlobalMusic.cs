using UnityEngine;
using System.Collections;

namespace ScrambledWordGame
{
	
	public class SWGGlobalMusic : MonoBehaviour 
	{
		[Tooltip("The tag of the music source")]
		public string musicTag = "Music";
		
		[Tooltip("The time this instance of the music source has been in the game")]
		internal float instanceTime = 0;

	
		void  Awake()
		{

			GameObject[] musicObjects = GameObject.FindGameObjectsWithTag(musicTag);
			
			if ( musicObjects.Length > 1 )
			{
				foreach( var musicObject in musicObjects )
				{
					if ( musicObject.GetComponent<SWGGlobalMusic>().instanceTime <= 0 )    Destroy(gameObject);
				}
			}
		}

		
		void  Start()
		{
			DontDestroyOnLoad(transform.gameObject);
		}
		
	}
}
