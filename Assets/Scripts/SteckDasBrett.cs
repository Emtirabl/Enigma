using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteckDasBrett : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip steck, entsteck;
    public Gradient colorGradient;
    public Transform canvas;
    bool start=true, drawLine;
    List<string> pairs = new List<string>();
    public string letters = "";
    string pair;
    SteckerLetter oldLetter;
    public LineRenderer line;
    List<LineRenderer> lines = new List<LineRenderer>();
    Color color;
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit2D[] results = new RaycastHit2D[1];
            Physics2D.RaycastNonAlloc(Input.mousePosition, Vector2.zero, results);
            if(results[0] && results[0].collider.gameObject.TryGetComponent<SteckerLetter>(out SteckerLetter letter))
            {
                if (letters.Contains(letter.letter))
                {
                    letter.connectedLetter.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
                    letter.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
                    int index = (int)Mathf.Floor(letters.IndexOf(letter.letter)/2);
                    pairs.RemoveAt(index);
                    Destroy(lines[index]);
                    lines.RemoveAt(index);
                    letters = letters.Remove(index*2, 2);
                    letter.connectedLetter.connectedLetter = null;
                    letter.connectedLetter = null;
                    source.PlayOneShot(entsteck);
                }
                else
                {
                    if (start)
                    {
                        pair = letter.letter;
                        oldLetter = letter;
                        letters += letter.letter;
                        float num = 0.04f * ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(letter.letter));
                        color = colorGradient.Evaluate(num);
                        letter.GetComponent<Image>().color = color;
                        DrawLine(cam.ScreenToWorldPoint(letter.transform.position), cam.ScreenToWorldPoint(letter.transform.position), color);
                        drawLine = true;
                        source.PlayOneShot(steck);
                    }
                    else
                    {
                        pair += letter.letter;
                        oldLetter.connectedLetter = letter;
                        letters += letter.letter;
                        letter.connectedLetter = oldLetter;
                        pairs.Add(pair);
                        letter.GetComponent<Image>().color = color;
                        MoveLine(lines[lines.Count - 1], cam.ScreenToWorldPoint(letter.transform.position));
                        Plugboard pb = new Plugboard(pairs.ToArray());
                        Enigma.instance.ChangePlugboard(pb);
                        drawLine = false;
                        source.PlayOneShot(steck);
                    }
                    start = !start;
                }
                
            }
        }
        if(drawLine)
        {
            MoveLine(lines[lines.Count - 1], cam.ScreenToWorldPoint(Input.mousePosition));
        }
    }
    public void DrawLine(Vector2 startPos, Vector2 endPos, Color color)
    {
        LineRenderer l = Instantiate(line);
        lines.Add(l);
        l.SetPosition(0, startPos);
        l.SetPosition(1, endPos);
        l.startColor = color; l.endColor = color;

    }
    public void MoveLine(LineRenderer l, Vector2 pos)
    {
        l.SetPosition(1, pos);
    }
}
