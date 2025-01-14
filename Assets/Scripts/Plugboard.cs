using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugboard : MonoBehaviour
{
    string alphabet;
    string wiring;
    public Plugboard(string[] pairs)
    {
        alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        wiring = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        foreach (string pair in pairs)
        {
            char a = pair[0];
            char b = pair[1];
            string wiring2 = wiring;
            string[] parts = wiring.Split(new char[2]{ a, b});
            if(a>b) wiring = parts[0]+ a +parts[1]+b+parts[2];
            else wiring = parts[0] + b + parts[1] + a + parts[2];
        }
    }
    public int forward(int index)
    {
        char letter = wiring[index];
        index = alphabet.IndexOf(letter);
        
        return index;
    }
    public int backward(int index)
    {
        char letter = alphabet[index];
        index = wiring.IndexOf(letter);
        return index;
    }
}
