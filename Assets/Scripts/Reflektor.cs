using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Reflektor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string letter;
    public Vector2 platz;
    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public string wiring;
    private void Awake()
    {
        platz = transform.position;
    }
    private void Start()
    {
        
        alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
    private void Update()
    {
        if (move) transform.position = Input.mousePosition;
    }
    public Reflektor(string w)
    {
        alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        wiring = w;
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
    bool move;
    ReflektorSlot reflektorSlot = null;
    //public void OnPointerMove(PointerEventData eventData)
    //{
    //    if (move) transform.position = eventData.position;
    //}

    public void OnPointerUp(PointerEventData eventData)
    {
        move = false;
        RaycastHit2D[] results = new RaycastHit2D[1];
        Physics2D.RaycastNonAlloc(eventData.position, Vector2.down, results);
        foreach (RaycastHit2D result in results)
        {
            if (result && result.collider.gameObject.TryGetComponent<ReflektorSlot>(out ReflektorSlot slot))
            {
                if (slot.reflektor != null)
                {
                    slot.reflektor.transform.position = slot.reflektor.platz;
                }
                if (reflektorSlot != null)
                {
                    reflektorSlot.reflektor = null;
                    Enigma.instance.ChangeWalze(reflektorSlot.slot, null);
                }
                Enigma.instance.ChangeReflektor(this);
                transform.position = slot.gameObject.transform.position;
                slot.reflektor = this;
                reflektorSlot = slot;
            }
            else
            {
                if (reflektorSlot != null)
                {
                    reflektorSlot.reflektor = null;
                    Enigma.instance.ChangeWalze(reflektorSlot.slot, null);
                }
                transform.position = platz;
            }
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        move = true;
    }
}
