using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int max_hp = 300;
    public GameObject hp_bar;
    public int damagePerHit = 50;

    private Collider2D target;

    private float speed = 1.0f;
    private bool isdead = false;
    private bool isTouchingHero = false;
    private float damageInterval = 0.8f;
    float damageTimer = 0f;
    private Hero targetHero;
    private potato targetPotato;
     bool isTriggerWithHero = false;
    private hero2 targetHero2;
    Collider2D enemyCollider;
    Animator anim;
    Rigidbody2D rb;
    Collider2D col;

    void Start()
    {
        hp = max_hp;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isdead) return;

        if (!isTouchingHero)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (hp <= 0)
        {
            Dead();
        }

        if (isTouchingHero && target != null)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                // 嘗試直接扣對方的 hp（無需知道類型，只要有 hp 欄位）
                Component comp = target.GetComponent<MonoBehaviour>();
                var hpField = comp.GetType().GetField("hp");

                if (hpField != null)
                {
                    int currentHp = (int)hpField.GetValue(comp);
                    hpField.SetValue(comp, currentHp - damagePerHit);
                }

                damageTimer = 0f;   
            }
        }

        if (hp_bar != null)
        {
            hp_bar.transform.localScale = new Vector3((float)hp / max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("hero")){
            isTriggerWithHero = true;
            speed = 0f;
            targetHero = other.GetComponent<Hero>();
            targetPotato = other.GetComponent<potato>();
            targetHero2 = other.GetComponent<hero2>();
            GetComponent<Animator>().SetBool("attack", true);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("hero"))
        {
            isTouchingHero = false;
            target = null;
            damageTimer = 0f;
            anim.SetBool("attack", false);
        }
    }

    void AttackHero(){
        if(targetHero!=null){
            targetHero.hp -= 20;
        }
        if(targetPotato!=null){
            targetPotato.hp -= 20;
        if(targetHero2!=null){
            targetHero2.hp -= 20;
        }
    }
    }

    void Dead()
    {
        isdead = true;
        rb.simulated = false;
        col.enabled = false;
        anim.SetTrigger("dead");
    }

    public void Onenemy_deadAnimationEnd()
    {
        Destroy(gameObject);
    }
}

