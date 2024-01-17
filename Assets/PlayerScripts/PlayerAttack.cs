using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public Animator _anim;
        public Renderer ren;
        public GameObject canvas;
        public Collider col;
        void Start()
        {
            ren.GetComponent<Renderer>();
            ren.enabled = false;
            _anim = GetComponent<Animator>();
            col.enabled = false;
        }
    
        void Update()
        {
            if (canvas.activeInHierarchy == false)
            {
                Attack();
            }
        }
        void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            { 
                if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle") ||
                    _anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.WalkForwardBattle"))
                {
                    _anim.Play("Base Layer.Attack02", 0, 0f);
                    Invoke("Show", 0.3f);
                    Invoke("Hide", 0.55f);
                }
            }
        }

        void Hide()
        {
            col.enabled = false;
            ren.enabled = false;
        }

        void Show()
        {
            col.enabled = true;
            ren.enabled = true;
        }
    }
}