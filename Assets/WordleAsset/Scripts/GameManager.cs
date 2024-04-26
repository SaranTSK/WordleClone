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

        public GameplayPanel GameplayPanel => gameplayPanel;
        [SerializeField] private GameplayPanel gameplayPanel;
        public KeyboardPanel KeyboardPanel => keyboardPanel;
        [SerializeField] private KeyboardPanel keyboardPanel;
        public ResultPanel ResultPanel => resultPanel;
        [SerializeField] private ResultPanel resultPanel;

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

        private void Update()
        {
            if (Input.GetKeyDown(UnityEngine.KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKeyDown(UnityEngine.KeyCode.R))
            {
                OnStartGame();
            }
        }

        private void Init()
        {
            StartCoroutine(InitAndWaitUntilCompleted());
        }

        private IEnumerator InitAndWaitUntilCompleted()
        {
            state = GaemState.None;

            gameplayPanel.Init();
            keyboardPanel.Init();
            resultPanel.Init();

            yield return new WaitUntil(() => gameplayPanel.IsInit && keyboardPanel.IsInit && resultPanel.IsInit);

            OnStartGame();
        }

        #region GameState Action
        public void OnStartGame()
        {
            Debug.Log("OnStartGame");
            // 1 Create gameplay and keyboard status
            state = GaemState.StartGame;
            gameplayPanel.Clear();
            keyboardPanel.Clear();
            // 2 Random new 5 letters word
            gameplayPanel.RandomGuessWord();
        }

        public void OnEndGame()
        {
            Debug.Log("OnEndGame");
            // 1 Show result or show answer
            state = GaemState.EndGame;
        }
        #endregion
    }
}
