using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public Animator anim;
    public Renderer attackRen;
    public Collider attackCol;
    public float speed = 5f;
    private int health = 7;
    private float cooldown = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        float distance = Vector3.Distance (player.transform.position, transform.position);
        if (distance >= 1)
        {
            FollowPlayer();
            anim.Play("RunForwardBattle");
        }

        if (distance < 1)
        {
            cooldown += Time.deltaTime;
            if (cooldown >= 2f)
            {
                cooldown = cooldown % 2f;
                anim.Play("Attack01");
                attackRen.enabled = true;
                attackCol.enabled = true;
            }
        }
    }
    void FollowPlayer()
    {
        Vector3 playPos = player.position;
        Vector3 pos = Vector3.MoveTowards(transform.position, playPos, 
            speed * Time.deltaTime);
        rb.MovePosition(pos);
        Vector3 adjust = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(adjust);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            health -= 1;
        }
    }
}
