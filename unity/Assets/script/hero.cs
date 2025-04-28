using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;


public class hero : MonoBehaviour
{
    bool isCollidingWithEnemy = false;
    float damageTimer = 0f;
    float damageInterval = 1.5f;
    Collider2D heroCollider;
    void Start()
    {
        heroCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollidingWithEnemy && damageTimer >= damageInterval){
            DealDamageToEnemy();
            damageTimer = 0f;
        }
        damageTimer += Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy")){
            isCollidingWithEnemy = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy")){
            isCollidingWithEnemy = false;
            damageTimer = 0f;
        }
    }
    void DealDamageToEnemy(){
        if(!isCollidingWithEnemy) return;

        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int contactsCount = heroCollider.GetContacts(contacts);

        for(int i=0;i<contactsCount;i++){
            GameObject enemy = contacts[i].collider.gameObject;
            if(enemy.CompareTag("enemy")){
                enemy enemyScript = enemy.GetComponent<enemy>();
                if(enemyScript!=null){
                    enemyScript.hp -= 20;
                }
            }
        }
    }
}
