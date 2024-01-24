using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerAttributes : MonoBehaviour
    {
        public Slider playerHealth;
        public Animator anim;
        public Renderer ren;
        public GameObject canvas;
        private Color color;
        private float count = 0;

        private void Start()
        {
            color = ren.material.GetColor("_Color");
            canvas.SetActive(false);
            playerHealth.value = 1;
        }

        void Update()
        {
            if (playerHealth.value <= 0)
            {
                canvas.SetActive(true);
                anim.Play("Die");
                Invoke("Stop", 3);
            }
            else
            {
                if (ren.material.GetColor("_Color") != color)
                {
                    count += Time.deltaTime;
                    if (count >= 0.3f)
                    {
                        count = 0;
                        ren.material.SetColor("_Color", color);
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "EnemyAttack")
            {
                ren.material.SetColor("_Color", Color.red);
                playerHealth.value -= 0.3f;
            }
        }

        private void Stop()
        {
            Time.timeScale = 0;
        }
        
    }
}
