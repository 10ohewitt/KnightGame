using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear : MonoBehaviour
{
    private Collider col;
    private Vector3 pos;
    private Vector3 x;
    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
        pos = transform.position;
        x = transform.position;
        x.y -= 100f;
        transform.position = x;
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            col.enabled = true;
            transform.position = pos;
        }
    }
}
