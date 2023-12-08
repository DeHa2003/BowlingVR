using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControlManyOBJS : MonoBehaviour
{
    public string deviceName;

    private KeywordRecognizer keywordRecognizerCUBES;
    private KeywordRecognizer keywordRecognizerACTIONS;
    public Dictionary<string, Action> cubes = new Dictionary<string, Action>();
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
        deviceName = Microphone.devices[0];

        cubes.Add("Cube one activate", Cube);
        cubes.Add("Cube two activate", Cube);
        cubes.Add("Cube three activate", Cube);

        ActivateVoiceCube();
    }

    private void ActivateVoiceCube()
    {
        keywordRecognizerCUBES = new KeywordRecognizer(cubes.Keys.ToArray());
        keywordRecognizerCUBES.OnPhraseRecognized += RecognizerSpeechCUBES;
        keywordRecognizerCUBES.Start();
    }
    private void RecognizerSpeechCUBES(PhraseRecognizedEventArgs phrase)
    {
        Debug.Log(phrase.text);
        cubes[phrase.text].Invoke();
    }
    private void Cube()
    {

    }

    private void ActivateVoiceActions()
    {
        keywordRecognizerACTIONS = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizerACTIONS.OnPhraseRecognized += RecognizerSpeechActions;
        keywordRecognizerACTIONS.Start();
    }
    private void RecognizerSpeechActions(PhraseRecognizedEventArgs phrase)
    {
        Debug.Log(phrase.text);
        cubes[phrase.text].Invoke();
    }
}
