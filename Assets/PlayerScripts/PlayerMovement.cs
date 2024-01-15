using System;
using UnityEngine;

namespace Player
{
    public class TopDownCharacterMover : MonoBehaviour
    {
        public Animator anim;
        [SerializeField] float moveSpeed = 4f;
        Vector3 forward, right;
        public GameObject canvas;
        public Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
        }

        void Update ()
        {
            if (canvas.activeInHierarchy == false)
            {
                if (Input.GetAxisRaw("Horizontal") == 0f && Input.GetAxisRaw("Vertical") == 0f)
                {
                    anim.SetBool("Walk", false);
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle"))
                {
                    anim.SetBool("Walk", true);
                    anim.Play("WalkForwardBattle");
                }

                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle_Battle") ||
                    anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.WalkForwardBattle"))
                {
                    forward = Camera.main.transform.forward;
                    forward.y = 0;
                    forward = Vector3.Normalize(forward);
                    right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

                    Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                    if (direction.magnitude > 0.1f)
                    {
                        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
                        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");

                        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
                        transform.forward = heading;
                        rb.velocity = (heading * moveSpeed);
                    }
                }
            }
        }
    }
}