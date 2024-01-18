using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerAttributes : MonoBehaviour
    {
        public Slider playerHealth;
        public Animator anim;
        public Collider player;

        private void Start()
        {
            player = GetComponent<Collider>();
            playerHealth.value = 1;
        }

        void Update()
        {
            if (playerHealth.value <= 0)
            {
                anim.Play("Die");
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "EnemyAttack")
            {
                playerHealth.value -= 0.3f;
            }
        }
    }
}
