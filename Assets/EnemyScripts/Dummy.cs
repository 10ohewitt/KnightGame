using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Animator anim;
    private int _health = 3;
    public Collider col;

    void Start()
    {
        col = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            _health -= 1;
            if (_health <= 0)
            {
                anim.Play("died");
                col.enabled = false;
            }
            else
            {
                anim.Play("pushed");
            }
        }
    }
}
