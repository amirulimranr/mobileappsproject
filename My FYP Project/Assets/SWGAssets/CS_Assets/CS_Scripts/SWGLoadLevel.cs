using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

namespace ScrambledWordGame
{
	
	public class SWGLoadLevel : MonoBehaviour
	{
		[Tooltip("How many seconds to wait before loading a level or URL")]
		public float loadDelay = 1;

		[Tooltip("The name of the URL to be loaded")]
		public string urlName = "";

		[Tooltip("The name of the level to be loaded")]
		public string levelName = "";

		[Tooltip("Loading sound and its source")]
		public AudioClip soundLoad;
		public string soundSourceTag = "Sound";
		public GameObject soundSource;

		internal GameObject gameController;

		void Start()
		{
			if ( GameObject.FindGameObjectWithTag("GameController") )    gameController = GameObject.FindGameObjectWithTag("GameController");

			if ( !soundSource && GameObject.FindGameObjectWithTag(soundSourceTag) )    soundSource = GameObject.FindGameObjectWithTag(soundSourceTag);
		}

		public void LoadURL()
		{
			Time.timeScale = 1;

			if ( soundSource && soundLoad )    soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

			Invoke("ExecuteLoadURL", loadDelay);
		}

		void ExecuteLoadURL()
		{
			Application.OpenURL(urlName);
		}
	
		public void LoadLevel()
		{
			Time.timeScale = 1;

			if ( soundSource && soundLoad )    soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

			Invoke("ExecuteLoadLevel", loadDelay);
		}

		void ExecuteLoadLevel()
		{
			SceneManager.LoadScene(levelName);
		}

		public void RestartLevel()
		{
			Time.timeScale = 1;

			if ( soundSource && soundLoad )    soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

			Invoke("ExecuteRestartLevel", loadDelay);
		}
		
		void ExecuteRestartLevel()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void StartGame()
		{
			if ( gameController )    gameController.SendMessage("StartGame");
		}
	}
}