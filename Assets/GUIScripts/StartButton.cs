using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    public Button myButton;
    void Start()
    {
        myButton.onClick.AddListener(OnGui);
    }

    void OnGui()
    {
        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
    }
}
