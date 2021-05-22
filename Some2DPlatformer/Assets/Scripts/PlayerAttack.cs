using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPose;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;
    public Animator anim;

    private void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetKey(KeyCode.K))
                anim.SetTrigger("attack");

            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
            timeBetweenAttack -= Time.deltaTime;
    }

    public void OnAttack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, whatIsEnemy);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPose.position, attackRange);
    }
}
