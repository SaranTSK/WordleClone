using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Wordle
{
    public enum LetterStatus
    {
        Empty = 0,
        Correct = 1,
        Swap = 2,
        Wrong = 3,
    }

    public class GameplayLetter : MonoBehaviour
    {
        [Header("Component")]
        [SerializeField] private Image image;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text letterText;
        [Header("Custom")]
        [SerializeField] private Sprite emptySprite;
        [SerializeField] private Sprite filledSprite;

        private KeyCode keyCode;
        private LetterStatus letterStatus;

        public void Init(KeyCode keyCode, LetterStatus letterStatus)
        {
            this.keyCode = keyCode;
            this.letterStatus = letterStatus;

            SetLetterText(keyCode);
            SetLetterStatus(keyCode, letterStatus);
            SetLetterColor(letterStatus);
        }

        public void Clear()
        {
            Init(KeyCode.None, LetterStatus.Empty);
        }

        public void SetLetterColor(LetterStatus letterStatus)
        {
            switch (letterStatus)
            {
                case LetterStatus.Correct:
                    image.color = Color.green;
                    break;
                case LetterStatus.Swap:
                    image.color = Color.yellow;
                    break;
                case LetterStatus.Wrong:
                    image.color = WordleConstant.Color.darkGrey;
                    break;
                default:
                    image.color = WordleConstant.Color.lightGrey;
                    break;
            }
        }

        private void SetLetterText(KeyCode keyCode)
        {
            letterText.text = keyCode.ToString().ToUpper();
        }

        private void SetLetterStatus(KeyCode keyCode, LetterStatus letterStatus)
        {
            if(keyCode == KeyCode.None)
            {
                image.sprite = emptySprite;
                letterText.gameObject.SetActive(false);
            }
            else
            {
                image.sprite = filledSprite;
                letterText.gameObject.SetActive(true);
            }
        }    }
}
