using Unity.VisualScripting;
using UnityEngine;

public enum AttackType
{
    Melee,
    OneShot
}
public class Enemy_Base : MonoBehaviour, IDamageable
{
    [SerializeField] private AttackType attype;
    [SerializeField] private float max_hp = 300;
    [SerializeField] private float damageInterval = 0.8f;
    [SerializeField] private float damagePerHit = 50f;
    [SerializeField] private float speed = 1.0f;
    private float currspeed;
    public float hp;
    public GameObject hp_bar;
    private bool isdead = false;
    bool isTriggerWithHero;
    float damageTimer = 0f;
    private IDamageable targetHero;
    Animator anim;
    Rigidbody2D rb;
    Collider2D col;

    void Start()
    {
        hp = max_hp;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        currspeed = speed;
    }

    void Update()
    {
        if (isdead) return;
        transform.position -= new Vector3(currspeed * Time.deltaTime, 0, 0);

        if (isTriggerWithHero)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                AttackHero();
                damageTimer = 0f;   
            }
        }
        if (hp <= 0)
        {
            hp = 0;
            Dead();
        }
        hp_bar.transform.localScale = new Vector3((float)hp / max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hero"))
        {
            isTriggerWithHero = true;
            currspeed = 0f;
            targetHero = other.GetComponent<IDamageable>();
            GetComponent<Animator>().SetBool("attack", true);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("hero"))
        {
            isTriggerWithHero = false;
            damageTimer = 0f;
            anim.SetBool("attack", false);
            currspeed = speed;
        }
    }

    void AttackHero()
    {
        if (targetHero != null)
        {
            targetHero.takeDamage(damagePerHit);
        }
    }
    public void takeDamage(float amount)
    {
        hp -= amount;
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

