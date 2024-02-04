using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public Collider door;
    public Renderer key;
    public Collider keyC;
    public AudioSource pickup;
    public TextMeshProUGUI text;

    void Start()
    {
        text.SetText("Pick up the key to the castle (West)");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            door.enabled = true;
            key.enabled = false;
            keyC.enabled = false;
            text.SetText("Enter the castle (North)");
            pickup.Play();
        }
    }
}
