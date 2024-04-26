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

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            CreateKeyboardKey();
        }

        private void CreateKeyboardKey()
        {
            for(int row = 0; row < keyRows.Count; row++)
            {
                for (int col = 0; col < keyRows[row].keys.Count; col++)
                {
                    Transform parent = keyboardParent.GetChild(row);
                    KeyboardKey key = Instantiate(keyPrefabs, parent);
                    key.Init(keyRows[row].keys[col]);
                }
            }
        }
    }
}

