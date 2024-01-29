using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Transform player;
    public Renderer shield;
    public Rigidbody rb;
    public Animator anim;
    public Collider attackCol;
    public Renderer head_ren;
    public Renderer body_ren;
    public Renderer feet_ren;
    public Renderer legs_ren;
    public Renderer hands_ren;
    private Color color;
    public float speed = 12f;
    public int health = 7;
    private float cooldown = 0f;
    private float dis = 35f;
    private float count;
    private bool stop = false;
    private Collider col;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        color = head_ren.material.GetColor("_Color");
        col = GetComponent<Collider>();
        Hide();
        
    }
    void Update()
    {
        if (head_ren.material.GetColor("_Color") != color)
        {
            count += Time.deltaTime;
            if (count >= 0.3f)
            {
                count = 0;
                head_ren.material.SetColor("_Color", color);
                body_ren.material.SetColor("_Color", color);
                feet_ren.material.SetColor("_Color", color);
                legs_ren.material.SetColor("_Color", color);
                hands_ren.material.SetColor("_Color", color);
            }
        }
        if (health <= 0)
        {
            anim.Play("Skeleton@Death01_A");
            col.enabled = false;
        }
        else
        {
            Vector3 adjust = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(adjust);
            if (cooldown <= 2.5f)
            {
                cooldown += Time.deltaTime;
            }

            if (shield.enabled == false && stop)
            {
                rb.constraints = RigidbodyConstraints.None;
                stop = false;
            }

            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (stop == false && distance < dis && distance >= 5 && 
                (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle") || 
                 anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.SkelWalk")))
            {
                FollowPlayer();
                anim.SetBool("Walk", true);
                anim.Play("SkelWalk");
            }

            else if (distance < 5)
            {
                anim.SetBool("Walk", false);
                if (cooldown >= 2.5f)
                {
                    cooldown = cooldown % 2f;
                    anim.Play("SkelAttack");
                    Invoke("Show", 0.35f);
                    Invoke("Hide", 0.5f);
                }
            }
            else if (distance > dis)
            {
                anim.SetBool("Walk", false);
            }
        }
    }
    void FollowPlayer()
    {
        Vector3 playPos = player.position;
        Vector3 pos = Vector3.MoveTowards(transform.position, playPos, 
            speed * Time.deltaTime);
        rb.MovePosition(pos);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            head_ren.material.SetColor("_Color", Color.red);
            body_ren.material.SetColor("_Color", Color.red);
            feet_ren.material.SetColor("_Color", Color.red);
            legs_ren.material.SetColor("_Color", Color.red);
            hands_ren.material.SetColor("_Color", Color.red);
            health -= 1;
        }
        else if (other.tag == "Shield")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | 
                             RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY; 
            anim.SetBool("Walk", false);
            stop = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | 
                             RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY; 
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    void Hide()
    {
        attackCol.enabled = false;
    }

    void Show()
    {
        attackCol.enabled = true;
    }
}
