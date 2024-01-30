using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private AudioSource aud;
    public Button myButton1;
    public Button myButton2;
    public Button myButton3;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        myButton1.onClick.AddListener(OnGUI);
        myButton2.onClick.AddListener(OnGUI);
        myButton3.onClick.AddListener(OnGUI);
        aud.Stop();
    }
    
    void OnGUI()
    {
        aud.Play();
    }
}
