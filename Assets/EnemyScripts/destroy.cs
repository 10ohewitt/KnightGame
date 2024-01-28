using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
}
