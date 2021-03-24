using UnityEngine;
using System;
using ScrambledWordGame.Types;

namespace ScrambledWordGame
{

    public class SWGWords : MonoBehaviour
    {
        internal SWGGameController gameController;

        public string[] words;

        internal int index;

        void Awake()
        {
            if ( GetComponent<SWGGameController>() ) gameController = GetComponent<SWGGameController>();

            if ( gameController && words.Length > 0 )
            {
                gameController.wordsWithHints = new WordWithHints[words.Length];

                for (index = 0; index < gameController.wordsWithHints.Length; index++) gameController.wordsWithHints[index] = new WordWithHints();

                for (index = 0; index < gameController.wordsWithHints.Length; index++) gameController.wordsWithHints[index].word = words[index];
            }
        }
	}
}