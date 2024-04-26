using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wordle
{
    public class GameManager : MonoBehaviour
    {
        public enum GaemState
        {
            None = 0,
            StartGame = 1,
            EndGame = 2,
        }

        public static GameManager Instance => instance;
        private static GameManager instance;

        public GaemState State => state;
        private GaemState state;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            state = GaemState.None;
        }

        #region GameState Action
        public void OnStartGame()
        {
            // 1 Reset gameplay and keyboard status
            // 2 Random new 5 letters word
        }

        public void OnEndGame()
        {
            // 1 Show result or show answer
        }
        #endregion
    }
}
