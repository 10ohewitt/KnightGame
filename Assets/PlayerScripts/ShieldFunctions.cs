using UnityEngine;

namespace Player
{
    public class Visibility : MonoBehaviour
    {
        public Animator _anim;
        public Renderer ren;
        public GameObject canvas;
        // Start is called before the first frame update
        void Start()
        {
            ren.GetComponent<Renderer>();
            ren.enabled = false;
            _anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (canvas.activeInHierarchy == false)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle") ||
                        _anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.WalkForwardBattle"))
                    {
                        _anim.Play("Base Layer.Defend", 0, 0f);
                        _anim.SetBool("Shield", true);
                        ren.enabled = true;
                    }
                    else
                    {
                        _anim.SetBool("Shield", false);
                        ren.enabled = false;
                    }
                }

                if (Input.GetMouseButtonUp(1))
                {
                    if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Defend"))
                    {
                        _anim.SetBool("Shield", false);
                        ren.enabled = false;
                    }
                }
            }

        }
    }
}