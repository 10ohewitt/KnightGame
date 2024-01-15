using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Animator anim;
    private int _health;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            _health -= 1;
            anim.Play("died");
            Debug.Log("work");
        }
        else
        {
            Debug.Log("why");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Done");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("dam");
    }
}
