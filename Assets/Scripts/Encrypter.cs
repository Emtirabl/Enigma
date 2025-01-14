using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Encrypter : MonoBehaviour
{
    Walze I;
    Walze II;
    Walze III;
    Walze IV;
    Walze V;
    Reflektor A;
    Reflektor B;
    Reflektor C;
    Plugboard pb;
    string key;
    string ring;
    public Enigma enigma;
    public TMP_InputField output;

    //void Start()
    //{
    //    I = new Walze("EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Z"[0]);
    //    II = new Walze("AJDKSIRUXBLHWTMCQGZNPYFVOE", "Z"[0]);
    //    III = new Walze("BDFHJLCPRTXVZNYEIWGAKMUSQO", "Z"[0]);
    //    IV = new Walze("ESOVPZJAYQUIRHXLNFTGKDCMWB", "Z"[0]);
    //    V = new Walze("VZBRGITYUPSDNHLXAWMJQOFECK", "Z"[0]);
    //    A = new Reflektor("EJMZALYXVBWFCRQUONTSPIKHGD");
    //    B = new Reflektor("YRUHQSLDPXNGOKMIEBFZCWVJAT");
    //    C = new Reflektor("FVPJIAOYEDRZXWGCTKUQSBNMHL");
    //    pb = new Plugboard(new string[] { "AB", "NH" });
    //    key = "CAT";
    //    ring = "AAA";
    //    enigma = new Enigma(pb, I, II, III, B, key, ring);
    //}
    private void Start()
    {
        Debug.Log(26 % 26 + "|" + -1 % 26);
    }
    public void encrypt(string message)
    {
        message = message.ToUpper();
        string encrypted = enigma.encrypt(message);
        output.text = encrypted;
    }
}
