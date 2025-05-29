using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
public class Spike : MonoBehaviour
{
    [SerializeField] private float SpikeDamage;
    [SerializeField] private float Interval;
    [SerializeField] private float speedEffect;
    [SerializeField] private float deadtime;
    private float timer=0f;
    private Dictionary<Collider2D, float> enemyTimers = new Dictionary<Collider2D, float>();
    private Dictionary<Enemy_Base, float> originalSpeeds = new Dictionary<Enemy_Base, float>();
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= deadtime)
        {
            Destroy(gameObject);
            timer = 0f;
        }
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Enemy_Base enemyscript = collision.GetComponent<Enemy_Base>();
            IDamageable targetenemy = collision.GetComponent<IDamageable>();

            if (enemyscript != null && targetenemy != null)
            {
                if (!enemyTimers.ContainsKey(collision))
                {
                    enemyTimers[collision] = 0f;
                    if (!originalSpeeds.ContainsKey(enemyscript))
                    {
                        originalSpeeds[enemyscript] = enemyscript.speed;
                        enemyscript.currspeed = originalSpeeds[enemyscript] * speedEffect;
                    }
                }

                enemyTimers[collision] += Time.deltaTime;
                if (enemyTimers[collision] >= Interval)
                {
                    targetenemy.takeDamage(SpikeDamage);
                    enemyTimers[collision] = 0f;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Enemy_Base enemyScript = collision.GetComponent<Enemy_Base>();
            if (enemyScript != null && originalSpeeds.ContainsKey(enemyScript))
            {
                enemyScript.currspeed = originalSpeeds[enemyScript];
                originalSpeeds.Remove(enemyScript);
            }

            if (enemyTimers.ContainsKey(collision))
            {
                enemyTimers.Remove(collision);
            }
        }
    }
}
