using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace ScrambledWordGame
{
	
	public class SWGSelectButton : MonoBehaviour 
	{
		
		public GameObject selectedButton;

		
		internal GameObject previousButton;

		
		public bool forceSelect = false;
	
		void OnEnable() 
		{
			if ( EventSystem.current ) 
			{
				
				previousButton = EventSystem.current.currentSelectedGameObject;
				
				if (selectedButton)    EventSystem.current.SetSelectedGameObject (selectedButton);
			}
		}

		void Update()
		{

			if ( forceSelect == true && EventSystem.current.currentSelectedGameObject == null )    EventSystem.current.SetSelectedGameObject(selectedButton);
		}

		public void RevertSelection()
		{

			EventSystem.current.SetSelectedGameObject(previousButton);
		}
	}
}
