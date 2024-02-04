using System;
using UnityEngine;

namespace PlayerScripts
{
    public class ColliderTest : MonoBehaviour
    {
        private int HP = 100;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Object entered the Trigger");
            Animator dragon = this.gameObject.GetComponent<Animator>();
            dragon.Play("Defend");
            HP = HP - 7;
            if (HP == 0)
            {
                dragon.Play("Die");
            }
        }
        private void OnTriggerStay (Collider other)
        {
            Debug.Log("Object is within trigger");
        }
        private void OnTriggerExit (Collider other)
        {
            Debug.Log("Object exited the Trigger");
        }
    }
}