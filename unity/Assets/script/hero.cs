using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;


public class hero : MonoBehaviour
{

    float damageTimer = 0f;
    float damageInterval = 1.5f;
    public int hp;
    public int max_hp = 400;
    public GameObject hp_bar;
    bool isTriggerWithEnemy = false;
    private enemy targetEnemy;
    Collider2D heroCollider;
    Rigidbody2D rb;
    Animator anim;
    bool isdead = false;

    void Start()
    {
        hp = 400;
        heroCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggerWithEnemy){
            damageTimer+=Time.deltaTime;
            if(damageTimer>=damageInterval){
                AttackEnemy();
                damageTimer=0f;
            }
        }
        if(hp<=0 && !isdead){
            hp=0;
            Dead();
        }
        hp_bar.transform.localScale = new Vector3((float)((float)hp/(float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy")){
            isTriggerWithEnemy = true;
            targetEnemy = collision.GetComponent<enemy>();
            GetComponent<Animator>().SetBool("attack", true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy")){
            isTriggerWithEnemy = false;
            targetEnemy = null;
            damageTimer = 0f;
            GetComponent<Animator>().SetBool("attack", false);
        }
    }
    void AttackEnemy(){
        if(targetEnemy!=null){
            targetEnemy.hp -= 35;
        }
    }

    void Dead(){
        isdead = true;

        rb.simulated = false;
        heroCollider.enabled = false;

        anim.SetTrigger("dead");
    }

    public void Onhero_deadAnimationEnd(){
        Destroy(gameObject);
    }
}
