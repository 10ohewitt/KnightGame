using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public Rigidbody proj;
    public float speed = 2f;
    public float projSpeed = 7f;
    public float dis = 4f;
    public float time = 1f;
    private float _run = 2f;
    private int health = 5;
    public Renderer ren;
    private Color color;
    private Color baseColor;
    private float count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        color = ren.material.color;
        baseColor = ren.material.GetColor("_Color");
    }
    
    void Update()
    {
        if (health <= 0)
        {
            color.a -= 0.005f;
            ren.material.color = color;
            if (color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (ren.material.GetColor("_Color") != baseColor)
            {
                count += Time.deltaTime;
                if (count >= 0.3f)
                {
                    count = 0;
                    ren.material.SetColor("_Color", baseColor);
                }
            }
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance > dis && distance < 50)
            {
                FollowPlayer();
            }

            if (distance < dis + 2f)
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
        playPos.y += 1f;
        Vector3 curPos = transform.position;
        curPos.y += 1f;
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
            ren.material.SetColor("_Color", Color.red);
            health -= 1;
        }
    }
}
