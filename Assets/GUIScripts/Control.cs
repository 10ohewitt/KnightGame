using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Button myButton;
    public Canvas main;
    public Canvas controls;
    void Start()
    {
        controls.enabled = false;
        myButton.onClick.AddListener(OnGui);
    }
    void OnGui()
    {
        controls.enabled = true;
        main.enabled = false;
    }
}
