using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int Health = 10;
    private Animator animator;
    public MoneyBank Base;
    bool canDamage = true;
    public HealthBar healthBar;
    public float difficult;
    NavMeshAgent walker;
    void Start()
    {
        animator = GetComponent<Animator>();
        Health += (int)(Health * 1.2 * (float)(difficult + 1));
        healthBar.SetMaxHealth(Health);
        walker= GetComponent<NavMeshAgent>();
        walker.speed += walker.speed * difficult / 7;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("isAttacking"))
        {
            if (canDamage)
            {
                Base.TakeDamage(Health);
                animator.SetBool("isAttacking", false);
                Destroy(gameObject, 1f);
                canDamage= false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health= 0;
            Die();
        }
        healthBar.SetHealth(Health);
    }

    private void Die()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject, 2f);
        Base.EarnBoost();
    }
    public bool WillDie(int damage)
    {
        if (Health - damage <= 0)
        {
            return true;
        }
        return false;
    }
}
