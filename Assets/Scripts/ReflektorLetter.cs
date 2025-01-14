using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReflektorLetter : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = GetComponentInParent<Reflektor>().letter;
    }
}
