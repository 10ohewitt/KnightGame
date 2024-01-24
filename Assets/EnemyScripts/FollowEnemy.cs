using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform enemy;
    public Animator anim;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 adjust = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(adjust);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Skeleton@Death01_A"))
        {
            Destroy(gameObject);
        }
        Vector3 pos = enemy.transform.position;
        pos.y += 1f; 
        transform.position = pos;
    }
}
