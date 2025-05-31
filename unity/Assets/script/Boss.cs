using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{
    enemy_spawner enemySpawner;
    public Transform spawnplace;
    public float max_hp = 1000f;
    public float curr_hp;
    private bool isDead = false;
    Animator anim;
    Rigidbody2D rb;
    Collider2D colid;

    void Start()
    {
        curr_hp = max_hp;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        colid = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (curr_hp <= 0)
        {
            curr_hp = 0;
            Dead();
        }
    }

    public void OnGenerateEnd()
    {
        anim.SetTrigger("fly");
    }

    public void takeDamage(float amount)
    {
        curr_hp -= amount;
    }

    void Dead()
    {
        isDead = true;
        rb.simulated = false;
        colid.enabled = false;
        anim.SetTrigger("destory");
        enemySpawner.EnemyDead();
    }

    public void OnBossAnimEnd()
    {
        Destroy(gameObject);
    }
    
}
