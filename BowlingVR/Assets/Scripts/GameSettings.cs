using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class GameSettings : MonoBehaviour
{
    public List<string> volumeValues = new List<string>();
    public List<AudioSource> sounds = new List<AudioSource>();
    public Slider slider;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> volume = new Dictionary<string, Action>();
    private string action;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < volumeValues.Count; i++)
        {
            volume.Add(volumeValues[i], Volume);
        }
        slider.value = sounds[1].volume * 10;

        keywordRecognizer = new KeywordRecognizer(volume.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs phrase)
    {
        action = phrase.text;
        volume[phrase.text].Invoke();
    }

    private void Volume()
    {
            switch (action)
            {
                case "volume one":
                    ChangeVolume(1);
                    break;
                case "volume two":
                    ChangeVolume(2);
                    break;
                case "volume three":
                    ChangeVolume(3);
                    break;
                case "volume four":
                    ChangeVolume(4);
                    break;
                case "volume five":
                    ChangeVolume(5);
                    break;
                case "volume six":
                    ChangeVolume(6);
                    break;
                case "volume seven":
                    ChangeVolume(7);
                    break;
                case "volume eight":
                    ChangeVolume(8);
                    break;
                case "volume nine":
                    ChangeVolume(9);
                    break;
                case "volume ten":
                    ChangeVolume(10);
                    break;
                case "volume zero":
                    ChangeVolume(0);
                    break;
            }
    }
    private void ChangeVolume(int newValues)
    {
        slider.value = newValues;
        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].volume = slider.value/10;
        }
    }

    public void SynchroneSound()
    {
        float posSound;
        posSound = sounds[0].time;

        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].time = posSound;
        }
    }
}
