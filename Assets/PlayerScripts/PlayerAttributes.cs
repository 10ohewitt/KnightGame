using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerAttributes : MonoBehaviour
    {
        public Slider playerHealth;
        public Slider heal;
        public Animator anim;
        public Renderer ren;
        public GameObject canvas;
        private Collider col;
        private Color color;
        private float count = 0;
        public AudioSource audioData;
        private Rigidbody rb;
        public Renderer shield;

        private void Start()
        {
            audioData = GetComponent<AudioSource>();
            audioData.Pause();
            rb = GetComponent<Rigidbody>();
            color = ren.material.GetColor("_Color");
            col = GetComponent<Collider>();
            canvas.SetActive(false);
            playerHealth.value = 1;
            heal.value = 1;
        }

        void Update()
        {
            if (playerHealth.value <= 0)
            {
                canvas.SetActive(true);
                anim.Play("Die");
                Invoke("Stop", 2);
                rb.constraints = RigidbodyConstraints.FreezePositionZ | 
                                 RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            }
            else
            {
                if (heal.value < 1)
                {
                    heal.value += Time.deltaTime / 20;
                }
                else if (Input.GetKey(KeyCode.F) && heal.value >= 1)
                {
                    playerHealth.value = 1;
                    heal.value = 0;
                }

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
            if (shield.enabled == false)
            {
                if (other.tag == "EnemyAttack")
                {
                    audioData.Play();
                    ren.material.SetColor("_Color", Color.red);
                    playerHealth.value -= 0.3f;
                }
            }
        }

        private void Stop()
        {
            Time.timeScale = 0;
        }
        
    }
}
