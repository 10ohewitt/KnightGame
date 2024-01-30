using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private AudioSource aud;
    private Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.Pause();
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnGUI);
    }
    
    void OnGUI()
    {
        aud.Play();
    }
}
