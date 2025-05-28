using UnityEngine;
using System.Collections.Generic;


public class conveyor : MonoBehaviour
{
    [SerializeField] private float speedEffect;
    private Dictionary<Enemy_Base, float> originalSpeeds = new Dictionary<Enemy_Base, float>();

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Enemy_Base enemyScript = collision.GetComponent<Enemy_Base>();

            if (enemyScript != null)
            {
                if (!originalSpeeds.ContainsKey(enemyScript))
                {
                    originalSpeeds[enemyScript] = enemyScript.speed;
                    enemyScript.currspeed = originalSpeeds[enemyScript] * speedEffect;
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("enemy"))
        {
            Enemy_Base enemyScript = collision.GetComponent<Enemy_Base>();
            if (enemyScript != null && originalSpeeds.ContainsKey(enemyScript))
            {
                enemyScript.currspeed = originalSpeeds[enemyScript];
                originalSpeeds.Remove(enemyScript);
            }
        }
    }
}