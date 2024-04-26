using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wordle
{
    [System.Serializable]
    public class KeyboardRow
    {
        public List<KeyCode> keys = new List<KeyCode>();
    }

    public class KeyboardPanel : MonoBehaviour
    {
        [SerializeField] private Transform keyboardParent;
        [SerializeField] private KeyboardKey keyPrefabs;
        [SerializeField] private List<KeyboardRow> keyRows = new List<KeyboardRow>();

        public bool IsInit => isInit;
        private bool isInit = false;

        public void Init()
        {
            CreateKeyboardKey();

            isInit = true;
        }

        public void Clear()
        {
            ResetKeyboardKey();
        }

        public void SetKeyboardKeyStatus(KeyCode keyCode, KeyStatus keyStatus)
        {
            for (int row = 0; row < keyRows.Count; row++)
            {
                Transform parent = keyboardParent.GetChild(row);

                for (int col = 0; col < keyRows[row].keys.Count; col++)
                {
                    KeyboardKey key = parent.GetChild(col).GetComponent<KeyboardKey>();
                    if(key.KeyCode == keyCode)
                    {
                        key.SetKeyStatus(keyStatus);
                        break;
                    }
                }
            }
        }

        private void CreateKeyboardKey()
        {
            for(int row = 0; row < keyRows.Count; row++)
            {
                Transform parent = keyboardParent.GetChild(row);

                for (int col = 0; col < keyRows[row].keys.Count; col++)
                {
                    KeyboardKey key = Instantiate(keyPrefabs, parent);
                    key.Init(keyRows[row].keys[col]);
                }
            }
        }

        private void ResetKeyboardKey()
        {
            for (int row = 0; row < keyRows.Count; row++)
            {
                Transform parent = keyboardParent.GetChild(row);

                for (int col = 0; col < keyRows[row].keys.Count; col++)
                {
                    KeyboardKey key = parent.GetChild(col).GetComponent<KeyboardKey>();
                    key.Clear();
                }
            }
        }
    }
}

