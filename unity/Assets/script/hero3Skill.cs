using System.Collections;
using UnityEngine;

public class hero3Skill : MonoBehaviour
{
    //color = 255 150 120 255
    private IDamageable targetenemy;
    private SpriteRenderer Sr;
    public float freezeDamagePerTime = 20f;
    public float duration = 3f;
    public float interval = 0.6f;
    Enemy_Base enemyScript;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            enemyScript = collision.GetComponent<Enemy_Base>();
            if (enemyScript != null)
            {
                enemyScript.ApplyFreeze(freezeDamagePerTime, duration, interval);
            }
        }
    }
}
