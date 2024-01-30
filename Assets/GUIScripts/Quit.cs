using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    private Button myButton;
    
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnGUI);
    }

    // Update is called once per frame
    void OnGUI()
    {
        Application.Quit();
    }
}
