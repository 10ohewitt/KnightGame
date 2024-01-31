using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Player
{
    public class Visibility : MonoBehaviour
    {
        public Animator anim;
        public Renderer ren;
        public Collider col;
        public GameObject canvas;
        public Slider shieldSlide;
        public AudioSource aud;
        void Start()
        {
            shieldSlide.value = 1;
            ren.GetComponent<Renderer>();
            col.GetComponent<Collider>();
            ren.enabled = false;
            col.enabled = false;
            anim = GetComponent<Animator>();
        }
        
        void Update()
        {
            if (shieldSlide.value <= 1f && ren.enabled == false)
            {
                shieldSlide.value += Time.deltaTime / 5;
            }
            if (canvas.activeInHierarchy == false)
            {
                if (Input.GetMouseButtonDown(1) && shieldSlide.value >= 1)
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle") ||
                        anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.WalkForwardBattle"))
                    {
                        shieldSlide.value = 0f;
                        aud.Play();
                        anim.Play("Base Layer.Defend", 0, 0f);
                        anim.SetBool("Shield", true);
                        ren.enabled = true;
                        col.enabled = true;
                    }
                    else
                    {
                        anim.SetBool("Shield", false);
                        ren.enabled = false;
                        col.enabled = false;
                    }
                }

                if (Input.GetMouseButtonUp(1))
                {
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Defend"))
                    {
                        anim.SetBool("Shield", false);
                        ren.enabled = false;
                        col.enabled = false;
                    }
                }
            }

        }
    }
}
