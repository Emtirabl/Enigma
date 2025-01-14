using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEnigma : MonoBehaviour
{
    public Walze w1, w2, w3;
    public WalzenSlot s1, s2, s3;
    public Reflektor r;
    public ReflektorSlot rs;

    private void Start()
    {
        s1.walze = w1;
        w1.transform.position = s1.transform.position;
        w1.walzenSlot = s1;
        s2.walze = w2;
        w2.transform.position = s2.transform.position;
        w2.walzenSlot= s2;
        s3.walze = w3;
        w3.transform.position = s3.transform.position;
        w3.walzenSlot = s3;
        rs.reflektor = r;
        r.transform.position = rs.transform.position;
        Enigma enigma = Enigma.instance;
        enigma.ChangeWalze(1, w1);
        enigma.ChangeWalze(2, w2);
        enigma.ChangeWalze(3, w3);
        enigma.ChangeReflektor(r);
    }
}
