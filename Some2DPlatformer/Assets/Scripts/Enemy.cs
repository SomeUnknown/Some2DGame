using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public int damage;
    public int health;
    private PlayerHealth playerHealth;
    private PlayerAnimation playerAnim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerAnim = FindObjectOfType<PlayerAnimation>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (timeBetweenAttack <= 0)
                anim.SetTrigger("enemyAttack");
            else
                timeBetweenAttack -= Time.deltaTime;
        }
            
    }

    public void OnEnemyAttack()
    {
        playerAnim.PlayerHitTakingAnim();
        playerHealth.health -= damage;
        timeBetweenAttack = startTimeBetweenAttack;
    }
}
