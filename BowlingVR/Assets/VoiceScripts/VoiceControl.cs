using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour
{
    public string deviceName;

    private KeywordRecognizer keywordRecognizer;
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
        deviceName = Microphone.devices[0];

        actions.Add("forward", Forward);
        actions.Add("back", Back);
        actions.Add("left", Left);
        actions.Add("right", Right);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizerSpeech;
        keywordRecognizer.Start();

        Debug.Log("fgdfgdfvfd");
    }

    private void RecognizerSpeech(PhraseRecognizedEventArgs phrase)
    {
        Debug.Log(phrase.text);
        actions[phrase.text].Invoke();
    }

    private void Forward()
    {
        transform.Translate(1, 0, 0);
    }
    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }
    private void Left()
    {
        transform.Translate(0, 0, 1);
    }
    private void Right()
    {
        transform.Translate(0, 0, -1);
    }
}
