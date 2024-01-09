using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
     public Renderer ren;
    // Start is called before the first frame update
    void Start()
    {
        ren.GetComponent<Renderer>();
        ren.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ren.enabled = true;
        }
        else
        {
            ren.enabled = false;
        }
    }
}
