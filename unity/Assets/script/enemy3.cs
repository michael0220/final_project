using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public int hp;
    public int maxhp = 300;
    public GameObject hpbar;
    public int damage = 50;
    private float walkspeed = 1.0f;
    private bool isdead = false;
    bool istriggerwithhero;
    //private float damagetime = 0.5f;
    //float damagetimer = 0f;
    private Hero targetHero;
    private hero2 targetHero2;
    private potato targetpotato;
    Collider2D Enemy2Colid;
    Animator anim;
    Rigidbody2D rb;
    Collider2D colid;

    void Start()
    {
        hp = maxhp;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        colid = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isdead)
        {
            return;
        }
        transform.position -= new Vector3(walkspeed * Time.deltaTime, 0, 0);
        if (hp <= 0)
        {
            Dead();
        }
        if (istriggerwithhero)
        {
            AttackHero();
        }
        hpbar.transform.localScale = new Vector3((float)hp / maxhp, hpbar.transform.localScale.y, hpbar.transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("hero")){
            istriggerwithhero = true;
            walkspeed = 0f;
            targetHero = other.GetComponent<Hero>();
            targetpotato = other.GetComponent<potato>();
            targetHero2 = other.GetComponent<hero2>();
            GetComponent<Animator>().SetBool("attack", true);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("hero"))
        {
            istriggerwithhero = false;
            //damageTimer = 0f;
            anim.SetBool("attack", false);
            walkspeed = 1.0f;
        }
    }

    void AttackHero()
    {
        
    }

    void Dead()
    {
        isdead = true;
        rb.simulated = false;
        colid.enabled = false;
        //anim.SetTrigger("dead");
    }
    
    public void DeadAnimEnd()
    {
        Destroy(gameObject);
    }
}
