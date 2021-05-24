using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float startTimeBetweenAttack;

    public Transform attackPose;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;
    public Animator anim;
    public Transform groundCheck;
    private bool isGrounded;

    private void Update()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
            isGrounded = true;
        else
            isGrounded = false;

        if (Input.GetKeyUp(KeyCode.K))
            if (!isGrounded)
            {
                attackRange = 3.0f;
                anim.Play("FlyingAttack");
            }
            else
            {
                attackRange = 1.5f;
                anim.Play("Attack1");
            }
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
