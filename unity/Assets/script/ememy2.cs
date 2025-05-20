using UnityEngine;

public class ememy2 : MonoBehaviour
{
    public int hp;
    public int maxhp = 90;
    public GameObject hpbar;
    public int damage = 50;
    private float walkspeed = 1.0f;
    private bool isdead = false;
    bool istriggerwithhero;
    private float damagetime = 0.5f;
    float damagetimer = 0f;
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
            damagetimer += Time.deltaTime;
            if (damagetimer >= damagetime)
            {
                AttackHero();
                damagetimer = 0f;
            }
        }
        hpbar.transform.localScale = new Vector3((float)hp / maxhp, hpbar.transform.localScale.y, hpbar.transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hero"))
        {
            istriggerwithhero = true;
            walkspeed = 0;
            targetHero = other.GetComponent<Hero>();
            targetHero2 = other.GetComponent<hero2>();
            targetpotato = other.GetComponent<potato>();
            GetComponent<Animator>().SetBool("attack", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("hero"))
        {
            istriggerwithhero = false;
            damagetimer = 0f;
            anim.SetBool("attack", false);
            walkspeed = 1.5f;
        }
    }

    void AttackHero()
    {
        if (targetHero != null)
        {
            targetHero.hp -= 50;
        }
        if (targetHero2 != null)
        {
            targetHero2.hp -= 50;
        }
        if (targetpotato != null)
        {
            targetpotato.hp -= 50;
        }
    }

    void Dead()
    {
        isdead = true;
        rb.simulated = false;
        colid.enabled = false;
        anim.SetTrigger("dead");
    }

    public void DeadAnimEnd()
    {
        Destroy(gameObject);
    }
}
