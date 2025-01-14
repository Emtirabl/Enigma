using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalzenNummer : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = GetComponentInParent<Walze>().nummer;
    }
}
