using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerAttributes : MonoBehaviour
    {
        public Slider playerHealth;
        public Animator anim;

        private void Start()
        {
            playerHealth.value = 1;
        }

        void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerHealth.value -= 0.3f;
            }
            if (playerHealth.value <= 0)
            {
                anim.Play("Die");
            }
            
        }
    }
}
