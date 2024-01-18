using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public Rigidbody proj;
    public GameObject obj;
    public float speed = 2f;
    public float projSpeed = 7f;
    public float dis = 4f;
    public float time = 1f;
    private float _run = 2f;
    private int health = 6;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(obj);
        }
        float distance = Vector3.Distance (player.transform.position, transform.position);
        if (distance > dis && distance < 10)
        {
            FollowPlayer();
        }
        else
        {
            Vector3 adjust = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(adjust);
            _run += Time.deltaTime;
            if (_run >= 3f)
            {
                _run = _run % 3f;
                Shoot();
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

    void Shoot()
    {
        Vector3 playPos = player.position;
        playPos.y += 0.4f;
        Vector3 curPos = transform.position;
        curPos.y += 0.5f;
        Rigidbody clone = Instantiate(proj, curPos, transform.rotation);
        Vector3 pos = Vector3.MoveTowards(curPos, playPos, 
            speed * Time.deltaTime);
        clone.velocity = transform.forward * projSpeed;
        Destroy(clone.GameObject(), time);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Attack")
        {
            health -= 1;
            Debug.Log(health);
        }
    }
}
