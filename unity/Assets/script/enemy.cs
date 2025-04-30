using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public GameObject hp_bar;
    public int max_hp=300;
    private float damageInterval = 0.8f;
    float damageTimer = 0f;
    float speed = 1.0f;
    private Hero targetHero;
    bool isTriggerWithHero = false;
    Collider2D enemyCollider;
    Animator anim;
    Rigidbody2D rb;
    bool isdead = false;

    void Start()
    {
        hp = 300f;
        enemyCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggerWithHero){
            damageTimer += Time.deltaTime;
            if(damageTimer>=damageInterval){
                AttackHero();
                damageTimer = 0f;
            }
        }
        if(isdead) return;
        this.gameObject.transform.position -= new Vector3(speed*Time.deltaTime, 0, 0);
        if(hp<=0 && !isdead)
        {
            hp=0;
            Dead();
        }
        hp_bar.transform.localScale = new Vector3((float)((float)hp/(float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("hero")){
            isTriggerWithHero = true;
            speed = 0f;
            targetHero = other.GetComponent<Hero>();
            GetComponent<Animator>().SetBool("attack", true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("hero")){
            isTriggerWithHero = false;
            speed = 1.0f;
            damageTimer = 0f;
            targetHero = null;
            GetComponent<Animator>().SetBool("attack", false);
        }
    }

    void AttackHero(){
        if(targetHero!=null){
            targetHero.hp -= 20;
        }
    }

    void Dead(){
        isdead = true;

        rb.simulated = false;
        enemyCollider.enabled = false;

        anim.SetTrigger("dead");
    }

    public void Onenemy_deadAnimationEnd(){
        Destroy(gameObject);
    }
}
