using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public Rigidbody proj;
    public float speed = 2f;
    public float projSpeed = 7f;
    public float dis = 2.5f;
    public float time = 1f;
    private float run = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float distance = Vector3.Distance (player.transform.position, transform.position);
        if (distance > dis)
        {
            FollowPlayer();
        }
        else
        {
            transform.LookAt(player);
            run += Time.deltaTime;
            if (run >= 3f)
            {
                run = run % 3f;
                Shoot();
            }
        }
    }
    void FollowPlayer()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, 
            speed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(player);
    }

    void Shoot()
    {
        Vector3 playPos = player.position;
        playPos.y = 5f;
        Vector3 curPos = transform.position;
        curPos.y = 5f;
        Rigidbody clone = Instantiate(proj, transform.position, transform.rotation);
        Vector3 pos = Vector3.MoveTowards(curPos, playPos, 
            speed * Time.deltaTime);
        clone.velocity = transform.forward * projSpeed;
        Destroy(clone, time);
    }
}
