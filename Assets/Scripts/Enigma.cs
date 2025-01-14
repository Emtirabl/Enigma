using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigma : MonoBehaviour
{
    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    Plugboard plugboard;
    Walze walze1;
    Walze walze2;
    Walze walze3;
    Reflektor reflektor;
    public static Enigma instance;
    public string key = "AAA", ring;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        plugboard = new Plugboard(new string[0]);
        alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        key = "AAA";
        ring = "AAA";
    }
    public Enigma(Plugboard pb, Walze w1, Walze w2, Walze w3, Reflektor r, string key, string ring)
    {
        alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        plugboard = pb;
        walze1 = w1;
        walze2 = w2;
        walze3 = w3;
        reflektor = r;
        walze1.setRing(ring[0]);
        walze2.setRing(ring[1]);
        walze3.setRing(ring[2]);

    }
    public void ChangeWalze(int slot, Walze walze)
    {
        switch(slot)
        {
            case 1:
                walze1 = walze;
                break;
            case 2:
                walze2 = walze;
                break;
            case 3:
                walze3 = walze;
                break;
        }
    }
    public void ChangeReflektor(Reflektor r)
    {
        reflektor = r;
    }
    public void ChangePlugboard(Plugboard pb)
    {
        plugboard = pb;
    }
    public void ChangeRing(string r)
    {
        ring = r;
    }
    public void ChangeKey(string k)
    {
        key = k;
    }
    public string encrypt(string message)
    {
        message = message.ToUpper();
        string encrypted = "";
        setKey(key);
        walze1.setRing(ring[0]);
        walze2.setRing(ring[1]);
        walze3.setRing(ring[2]);
        foreach (char c in message)
        {
            if (alphabet.Contains(c))
            {
                walze3.turn();
                if (walze2.testForNotch())
                {
                    walze2.turn();
                    if (walze1.testForNotch())
                    {
                        walze1.turn();
                    }
                }
                int index = alphabet.IndexOf(c);
                index = plugboard.forward(index);
                index = walze3.forward(index);
                index = walze2.forward(index);
                index = walze1.forward(index);
                index = reflektor.forward(index);
                index = walze1.backward(index);
                index = walze2.backward(index);
                index = walze3.backward(index);
                index = plugboard.backward(index);

                encrypted += alphabet[index];
            }
        }
        walze3.reset();
        walze2.reset();
        walze1.reset();
        return encrypted;
    }
    public void setKey(string key)
    {
        this.key = key;
        walze1.turnToLetter(key[0]);
        walze2.turnToLetter(key[1]);
        walze3.turnToLetter(key[2]);
    }
}
