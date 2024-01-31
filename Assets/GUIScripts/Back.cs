using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public Button myButton;
    public Canvas main;
    public Canvas controls;
    void Start()
    {
        myButton.onClick.AddListener(OnGui);
    }
    
    void OnGui()
    {
        main.enabled = true;
        controls.enabled = false;
        
    }
}
