using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Walze : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 platz;
    public string nummer;
    string origAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string origWiring;
    public string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string wiring;
    public char notch;
    RectTransform rect;
    //private void Awake()
    //{
    //    rect = GetComponent<RectTransform>();
    //}
    private void Awake()
    {
        platz = transform.position;
    }

    private void Update()
    {
        if (move) transform.position = Input.mousePosition;
    }
    private void Start()
    {
        origWiring = wiring;
        origAlphabet = alphabet;
    }
    public Walze(string w,char n)
    {
        wiring = w;
        notch = n;
        origWiring = w;
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
    public void oppositeTurn()
    {
        string part = wiring.Trim(wiring[25]);
        wiring = wiring[25]+part;
        part = alphabet.Trim(alphabet[25]);
        alphabet = alphabet[25] + part;
    }
    public void turn()
    {
        string part = wiring.TrimStart(wiring[0]);
        wiring = part+wiring[0];
        part = alphabet.TrimStart(alphabet[0]);
        alphabet = part + alphabet[0];
    }
    public void turnToLetter(char letter)
    {
        int index = alphabet.IndexOf(letter);
        string[] parts = alphabet.Split(alphabet[index]);
        alphabet = letter+parts[1]+parts[0];
        string[] parts2 = wiring.Split(wiring[index]);
        wiring = wiring[index] + parts2[1] + parts2[0];
    }
    public bool testForNotch()
    {
        if(alphabet[0] == notch)
        {
            return true;
        }
        return false;
    }
    public void reset()
    {
        alphabet = origAlphabet;
        wiring = origWiring;
    }
    public void setRing(char letter)
    {
        int index = alphabet.IndexOf(letter);
        string[] parts = wiring.Split(wiring[25-index]);
        wiring = parts[1] + parts[0] + wiring[25 - index];
        string[] parts2 = alphabet.Split(alphabet[25-index]);
        alphabet = parts2[1]+parts2[0] + alphabet[25 - index];
        int newNotch = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(notch);
        if(newNotch-index<0)
        {
            newNotch += 26;
        }
        notch = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[(newNotch - index)%26];
    }


    bool move;
    public WalzenSlot walzenSlot = null;
    //public void OnPointerMove(PointerEventData eventData)
    //{
    //    if (move) transform.position = eventData.position;
    //}

    public void OnPointerUp(PointerEventData eventData)
    {
        move = false;
        RaycastHit2D[] results = new RaycastHit2D[1];
        Physics2D.RaycastNonAlloc(eventData.position, Vector2.down, results);
        foreach(RaycastHit2D result in results)
        {
            Debug.Log(result.collider.name);
            if(result && result.collider.gameObject.TryGetComponent<WalzenSlot>(out WalzenSlot slot))
            {
                
                    if (slot.walze != null)
                    {
                        slot.walze.transform.position = slot.walze.platz;
                        slot.walze.reset();
                    slot.walze.walzenSlot = null;
                        if (walzenSlot != null)
                        {
                            slot.walze.transform.position = walzenSlot.transform.position;
                            walzenSlot.walze = slot.walze;
                        slot.walze.walzenSlot = walzenSlot;
                            Enigma.instance.ChangeWalze(walzenSlot.slot, slot.walze);
                        }
                    }
                    Enigma.instance.ChangeWalze(slot.slot, this);
                    transform.position = slot.gameObject.transform.position;
                    slot.walze = this;
                    walzenSlot = slot;
                
            }
            else
            {
                if (walzenSlot != null)
                {
                    transform.position = walzenSlot.transform.position;
                }
                else
                {
                    transform.position = platz;
                }
                
            }
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        move = true;
        
    }
}
