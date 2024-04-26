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

        private Color lerpedColor = WordleConstant.Color.lightGrey;
        private float lerpTime = 1f;
        private float lerpDuration = 1f;

        private void Update()
        {
            UpdateWarning();
        }

        public void Init(KeyCode keyCode, LetterStatus letterStatus)
        {
            SetWarning(false);
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

        public void SetWarning(bool value)
        {
            lerpTime = value ? 0f : lerpDuration * 2f;
        }

        private void UpdateWarning()
        {
            if (lerpTime < lerpDuration)
            {
                lerpTime += Time.deltaTime;
                lerpedColor = Color.Lerp(WordleConstant.Color.lightGrey, Color.red, Mathf.PingPong(lerpTime * 2f, 1));
                image.color = lerpedColor;
            }
        }

        private void SetLetterText(KeyCode keyCode)
        {
            letterText.text = keyCode.ToString().ToUpper();
        }

        private void SetLetterStatus(KeyCode keyCode, LetterStatus letterStatus)
        {
            if (keyCode == KeyCode.None)
            {
                image.sprite = emptySprite;
                letterText.gameObject.SetActive(false);
            }
            else
            {
                image.sprite = filledSprite;
                letterText.gameObject.SetActive(true);
            }
        }
    }
}
