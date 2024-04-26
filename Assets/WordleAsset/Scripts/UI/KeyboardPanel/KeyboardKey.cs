using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Wordle
{
    public enum KeyStatus
    {
        Empty = 0,
        Correct = 1,
        Wrong = 2,
    }

    public enum KeyCode
    {
        None = 0,
        Delete = 1,
        Confirm = 2,

        A = 3,
        B = 4,
        C = 5,
        D = 6,
        E = 7,
        F = 8,
        G = 9,
        H = 10,
        I = 11,
        J = 12,
        K = 13,
        L = 14,
        M = 15,
        N = 16,
        O = 17,
        P = 18,
        Q = 19,
        R = 20,
        S = 21,
        T = 22,
        U = 23,
        V = 24,
        W = 25,
        X = 26,
        Y = 27,
        Z = 28,
    }

    public class KeyboardKey : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text keyText;

        private KeyCode keyCode;
        private KeyStatus keyStatus;

        public void Init(KeyCode keyCode)
        {
            this.keyCode = keyCode;
            name = $"Key ({keyCode})";

            SetKeyStatus(KeyStatus.Empty);
            SetKeyText(keyCode);
            InitOnClick(keyCode);
        }

        public void SetKeyStatus(KeyStatus keyStatus)
        {
            this.keyStatus = keyStatus;
            SetKeyColor(keyStatus);
        }

        private void SetKeyColor(KeyStatus keyStatus)
        {
            switch (keyStatus)
            {
                case KeyStatus.Correct:
                    image.color = Color.green;
                    break;
                case KeyStatus.Wrong:
                    image.color = WordleConstant.Color.darkGrey;
                    break;
                default:
                    image.color = WordleConstant.Color.lightGrey;
                    break;
            }
        }

        private void SetKeyText(KeyCode keyCode)
        {
            keyText.text = keyCode.ToString();

            if(keyCode == KeyCode.Confirm || keyCode == KeyCode.Delete)
            {
                image.rectTransform.sizeDelta = new Vector2(200, 100);
            }
            else
            {
                image.rectTransform.sizeDelta = new Vector2(100, 100);
            }
        }

        private void InitOnClick(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.Confirm:
                    button.onClick.AddListener(OnClickConfirmKey);
                    break;
                case KeyCode.Delete:
                    button.onClick.AddListener(OnClickDeleteKey);
                    break;
                case KeyCode.A:
                case KeyCode.B:
                case KeyCode.C:
                case KeyCode.D:
                case KeyCode.E:
                case KeyCode.F:
                case KeyCode.G:
                case KeyCode.H:
                case KeyCode.I:
                case KeyCode.J:
                case KeyCode.K:
                case KeyCode.L:
                case KeyCode.M:
                case KeyCode.N:
                case KeyCode.O:
                case KeyCode.P:
                case KeyCode.Q:
                case KeyCode.R:
                case KeyCode.S:
                case KeyCode.T:
                case KeyCode.U:
                case KeyCode.V:
                case KeyCode.W:
                case KeyCode.X:
                case KeyCode.Y:
                case KeyCode.Z:
                    button.onClick.AddListener(OnClickNormalKey);
                    break;
                default:
                    Debug.LogError($"Invalid KeyCode: {keyCode}");
                    break;
            }
        }

        #region Button Action
        private void OnClickNormalKey()
        {
            // TODO: Call insert key input
            Debug.Log($"OnClick [{keyCode}] status [{keyStatus}]");
        }

        private void OnClickConfirmKey()
        {
            // TODO: Call confirm input
            Debug.Log($"OnClick [{keyCode}] status [{keyStatus}]");
        }

        private void OnClickDeleteKey()
        {
            // TODO: Call remove lasted key input
            Debug.Log($"OnClick [{keyCode}] status [{keyStatus}]");
        }
        #endregion
    }
}

