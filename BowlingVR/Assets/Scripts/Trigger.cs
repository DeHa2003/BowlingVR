using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int a = 0;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("Schet").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Earth"))
        {
            a = int.Parse(text.text);
            a += 1;
            text.text = a.ToString();
            Destroy(gameObject.GetComponent<Trigger>());
        }
    }
}
