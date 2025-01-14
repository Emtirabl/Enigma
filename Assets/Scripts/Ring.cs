using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ring : MonoBehaviour
{
    string ring;
    public TMP_InputField text;
    private void Start()
    {
        text = GetComponent<TMP_InputField>();
        text.text = "AAA";
        ring = "AAA";
        Enigma.instance.ChangeRing(ring);
    }
    public void ChangeRing(string r)
    {
        if(r.Length < 3)
        {
            int i = 3 - r.Length;
            for(int j = 0; j < i; j++)
            {
                r += "A";
            }
        }
        text.text = r.ToUpper();
        ring = r.ToUpper();
        Enigma.instance.ChangeRing(ring);
    }
}
