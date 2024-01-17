using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopDownCharacterMover : MonoBehaviour
{

    [SerializeField] public float speed = 5f;
    private Vector3 _forward;
       private Vector3 _right;
    private void Start()
    {
        _forward = Camera.main.transform.forward;
        _forward.y = 0f;
        _forward = Vector3.Normalize(_forward);
        _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _forward;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = _right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = _forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
    
}
 
