using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControlBowling : MonoBehaviour
{
    [Header("Панель")]
    public GameObject panel;
    public Transform mapZero;
    public Transform posAndRotPanel;
    public List<String> panelPhrase = new List<string>();
    private bool isOpenedPanel = false;
    private string action;
    //---------------------------------------------------//
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < panelPhrase.Count; i++)
        {
            actions.Add(panelPhrase[i], Play);
        }

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizerSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizerSpeech(PhraseRecognizedEventArgs phrase)
    {
        action = phrase.text;
        actions[phrase.text].Invoke();
    }

    private void Play()
    {
        switch (action)
        {
            case "open panel":
                isOpenedPanel = true;
                CheckStatusPanel();
                break;
            case "close panels":
                isOpenedPanel = false;
                CheckStatusPanel();
                break;
        }
    }

    private void CheckStatusPanel()
    {
        if (isOpenedPanel)
        {
            panel.SetActive(true);
            panel.transform.SetParent(mapZero);
            panel.transform.position = new Vector3(posAndRotPanel.position.x, Camera.main.transform.position.y, posAndRotPanel.position.z);
            panel.transform.eulerAngles = new Vector3(0, panel.transform.eulerAngles.y, 0);

            //panel.transform.position = Camera.main.transform.position;
            //panel.transform.SetPositionAndRotation(Camera.main.gameObject.transform.position + new Vector3(0, -0.1f, 0.8f), new Quaternion(0, 0, 0, 0));
        }
        else
        {
            panel.SetActive(false);
            panel.transform.SetParent(Camera.main.gameObject.transform);
            panel.transform.SetPositionAndRotation(gameObject.transform.parent.transform.position + new Vector3(0, -0.1f, 0.8f), new Quaternion(0, 0, 0, 0));
        }
    }
}
