using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Wordle
{
    public class ResultPanel : MonoBehaviour
    {
        [SerializeField] private Transform panel;
        [SerializeField] private Transform fade;
        [SerializeField] private Image titleImage;
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text answerText;
        [SerializeField] private TMP_Text resultText;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartButton;

        public bool IsInit => isInit;
        private bool isInit = false;

        public void Init()
        {
            exitButton.onClick.AddListener(OnClickExit);
            restartButton.onClick.AddListener(OnClickRestart);
            Hide();

            isInit = true;
        }

        public void Show(string answer, int round, bool isWin)
        {
            SetTitle(isWin);
            answerText.text = GetStringWithSpace(answer);
            resultText.text = GetRoundText(round);
            panel.gameObject.SetActive(true);
            fade.gameObject.SetActive(true);
        }

        public void Hide()
        {
            panel.gameObject.SetActive(false);
            fade.gameObject.SetActive(false);
        }

        private void SetTitle(bool isWin)
        {
            titleText.text = isWin ? "CONGRATULATION!" : "KEEP GOING!";
            titleImage.color = isWin ? Color.green : Color.red;
        }

        private string GetRoundText(int round)
        {
            return round == 1 ? $"Your finished in {round} round" : $"Your finished in {round} rounds";
        }

        private string GetStringWithSpace(string value)
        {
            string result = $"{value[0]}";
            for (int i = 1; i < value.Length; i++)
            {
                result += $" {value[i]}";
            }
            return result.ToUpper();
        }

        #region Button Action
        private void OnClickExit()
        {
            Application.Quit();
        }

        private void OnClickRestart()
        {
            Hide();
            GameManager.Instance.OnStartGame();
        }
        #endregion
    }
}
