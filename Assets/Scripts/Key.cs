using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    string key;
    public TMP_InputField text;
    private void Start()
    {
        text = GetComponent<TMP_InputField>();
        text.text = "AAA";
        key = "AAA";
        Enigma.instance.ChangeKey(key);
    }
    public void ChangeKey(string r)
    {
        if (r.Length < 3)
        {
            int i = 3 - r.Length;
            for (int j = 0; j < i; j++)
            {
                r += "A";
            }
        }
        text.text = r.ToUpper();
        key = r.ToUpper();
        Enigma.instance.ChangeKey(key);
    }
}
