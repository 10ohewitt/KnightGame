using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScene : MonoBehaviour
{
    public Canvas interact;

    private void Start()
    {
        interact.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Finish")
        {
            interact.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("bossFight", LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interact.enabled = false;
    }
}
