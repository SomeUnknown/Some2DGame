using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Invoke("DestroyEnemy", .8f);
            anim.SetBool("isDead", true);
        }
    }

    public void TakeDamage(int damage)
    {
        anim.SetBool("hitTaken", true);
        health -= damage;
        Invoke("TakingHitAnimCancel", .5f);
    }
    
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void TakingHitAnimCancel()
    {
        anim.SetBool("hitTaken", false);
    }
}
