using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public Canvas interact;

    private void Start()
    {
        interact.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        interact.enabled = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Princess")
        {
            interact.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("gameCompleted", LoadSceneMode.Single);
            }
        }
    }
}
