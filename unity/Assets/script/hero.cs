using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;


public class hero : MonoBehaviour
{
    bool isCollidingWithEnemy = false;
    float damageTimer = 0f;
    float damageInterval = 1.5f;
    float animate_timer = 0f;
    float animate_interval = 0.5f;

    public int hp;
    public int max_hp = 400;
    public GameObject hp_bar;

    Collider2D heroCollider;

    void Start()
    {
        hp = 400;
        heroCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0){
            hp=0;
            Destroy(this.gameObject);
        }
        if(isCollidingWithEnemy && damageTimer >= damageInterval){
            DealDamageToEnemy();
            damageTimer = 0f;
        }
        damageTimer += Time.deltaTime;
        hp_bar.transform.localScale = new Vector3((float)((float)hp/(float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy")){
            isCollidingWithEnemy = true;
            GetComponent<Animator>().SetBool("attack", true);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy")){
            isCollidingWithEnemy = false;
            damageTimer = 0f;
            GetComponent<Animator>().SetBool("attack", false);
        }
    }
    void DealDamageToEnemy(){
        if(!isCollidingWithEnemy) return;

        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int contactsCount = heroCollider.GetContacts(contacts);

        for(int i=0;i<contactsCount;i++){
            GameObject enemyObj = contacts[i].collider != null ? contacts[i].collider.gameObject : null;
            if(enemyObj != null && enemyObj.CompareTag("enemy")){
                enemy enemyScript = enemyObj.GetComponent<enemy>();
                if(enemyScript!=null){
                    enemyScript.hp -= 20;
                }
            }
        }
    }
}
