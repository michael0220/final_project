using System.Collections;
using UnityEngine;

public class hero3Skill : MonoBehaviour
{
    public float freezeDamagePerTime = 20f;
    public float duration = 3f;
    public float interval = 0.6f;
    public HeroType herotype;
    Enemy_Base enemyScript;
    Boss bossScript;
    void Start()
    {
        int level = UpgradeManager.Instance.Getlevel(herotype);

        freezeDamagePerTime += (level - 1) * 5;
        duration += (level - 1) * 0.5f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemyScript = collision.GetComponent<Enemy_Base>();
            bossScript = collision.GetComponent<Boss>();
            if (enemyScript != null && enemyScript.enemytype == EnemyType.enemy)
            {
                enemyScript.ApplyFreeze(freezeDamagePerTime, duration, interval);
            }
            else if(bossScript != null && bossScript.enemytype == EnemyType.boss)
            {
                bossScript.ApplyFreeze(freezeDamagePerTime, duration, interval);
            }
        }
    }
}
