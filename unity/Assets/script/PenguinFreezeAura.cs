using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinFreezeAura : MonoBehaviour
{
    public float attackInterval = 1.5f;
    public float freezeDuration = 2f;
    public float freezeDamage = 20f;
    public GameObject iceEffect;

    private List<Enemy> enemiesInRange = new List<Enemy>();
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackInterval)
        {
            foreach (Enemy enemy in enemiesInRange)
            {
                if (enemy != null)
                {
                    enemy.Freeze(freezeDuration, freezeDamage);
                    if (iceEffect != null)
                    {
                        Instantiate(iceEffect, enemy.transform.position, Quaternion.identity);
                    }
                }
            }
            timer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Enemy e = other.GetComponent<Enemy>();
            if (e != null && !enemiesInRange.Contains(e))
            {
                enemiesInRange.Add(e);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Enemy e = other.GetComponent<Enemy>();
            if (e != null && enemiesInRange.Contains(e))
            {
                enemiesInRange.Remove(e);
            }
        }
    }
}
