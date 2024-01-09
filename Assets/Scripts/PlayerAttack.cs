using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack01") == false)
            {
                _anim.Play("Base Layer.Attack01", 0, 0f);
            }
        }
    }
}
