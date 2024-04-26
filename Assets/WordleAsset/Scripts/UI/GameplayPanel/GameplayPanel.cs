using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Wordle
{
    public class GameplayPanel : MonoBehaviour
    {
        [Header("Header")]
        [SerializeField] private TMP_Text guessText;
        [Header("Content")]
        [SerializeField] private Transform wordGroupParent;
        [SerializeField] private GameplayLetter letterPrefab;
        [SerializeField] private int maxLetter = 5;

        private string randomLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private int guessRound = 0;
        private string targetWord = string.Empty;
        private string guessWord = string.Empty;

        private void Start ()
        {
            Init();
        }

        private void Update()
        {
            if(Input.GetKeyDown(UnityEngine.KeyCode.R))
            {
                targetWord = string.Empty;
                RandomGuessWord();
            }
        }

        public void Init()
        {
            CreateLetters();
            RandomGuessWord();
        }

        public void Clear()
        {
            guessRound = 0;
            guessWord = string.Empty;
            targetWord = string.Empty;
            ResetWordGroups();
        }

        #region Word Group Panel
        private void CreateLetters()
        {
            for (int row = 0; row < wordGroupParent.childCount; row++)
            {
                Transform parent = wordGroupParent.GetChild(row);

                for (int col = 0; col < maxLetter; col++)
                {
                    GameplayLetter key = Instantiate(letterPrefab, parent);
                    key.Init(KeyCode.None, LetterStatus.Empty);
                }
            }
        }

        private void ResetWordGroups()
        {
            for (int row = 0; row < wordGroupParent.childCount; row++)
            {
                Transform parent = wordGroupParent.GetChild(row);

                for (int col = 0; col < maxLetter; col++)
                {
                    GameplayLetter key = parent.GetChild(col).GetComponent<GameplayLetter>();
                    key.Init(KeyCode.None, LetterStatus.Empty);
                }
            }
        }
        #endregion

        #region Gameplay
        private void SetGuessText(string text)
        {
            guessText.text = $"WORDS = {text}";
        }

        public void RandomGuessWord()
        {
            char letter;
            int rand;
            for (int i = 0; i < maxLetter; i++)
            {
                do
                {
                    rand = Random.Range(1, randomLetters.Length);
                    letter = randomLetters[rand];
                } while (targetWord.Contains(letter));
                targetWord = targetWord + letter;
            }
            SetGuessText(targetWord);
        }

        public void AddGuessLetter(KeyCode keyCode)
        {
            if(guessWord.Length < maxLetter)
            {
                GameplayLetter letter = wordGroupParent.GetChild(guessRound).GetChild(guessWord.Length).GetComponent<GameplayLetter>();
                letter.Init(keyCode, LetterStatus.Empty);

                guessWord = guessWord + keyCode.ToString().ToUpper();
            }
        }

        public void RemoveGuessLetter()
        {
            if(guessWord.Length > 0)
            {
                GameplayLetter letter = wordGroupParent.GetChild(guessRound).GetChild(guessWord.Length - 1).GetComponent<GameplayLetter>();
                letter.Clear();

                guessWord = guessWord.Remove(guessWord.Length - 1);
            }
        }

        public void CheckGuessWord()
        {
            if(guessWord.Length == maxLetter)
            {
                int correctPoint = 0;
                for (int i = 0; i < maxLetter; i++)
                {
                    GameplayLetter letter = wordGroupParent.GetChild(guessRound).GetChild(i).GetComponent<GameplayLetter>();

                    if (IsCorrectLetter(guessWord[i], i))
                    {
                        correctPoint++;
                        letter.SetLetterColor(LetterStatus.Correct);
                    }
                    else if (IsCorrectSwap(guessWord[i]))
                    {
                        letter.SetLetterColor(LetterStatus.Swap);
                    }
                    else
                    {
                        letter.SetLetterColor(LetterStatus.Wrong);
                    }
                }

                CheckEndGame(correctPoint);
            }
            else
            {
                // TODO: Add feedback option
                Debug.LogWarning($"You must assign all letters");
            }
        }

        private bool IsCorrectLetter(char letter, int index)
        {
            return letter.Equals(targetWord[index]);
        }

        private bool IsCorrectSwap(char letter)
        {
            for (int i = 0; i < maxLetter; i++)
            {
                if (letter.Equals(targetWord[i]))
                    return true;
            }
            return false;
        }

        private void CheckEndGame(int correctPoint)
        {
            if (correctPoint == maxLetter)
            {
                // TODO: Call Endgame Panel
                Debug.Log($"You win in {guessRound} rounds");
            }
            else
            {
                CheckGuessRound();
            }
        }

        private void CheckGuessRound()
        {
            if(guessRound < wordGroupParent.childCount)
            {
                guessRound++;
                guessWord = string.Empty;
                targetWord = string.Empty;
            }
            else
            {
                // TODO: Call Endgame Panel
                Debug.Log($"You lose!!!");
            }
        }
        #endregion
    }
}
