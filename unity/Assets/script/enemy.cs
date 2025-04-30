using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp;
    public GameObject hp_bar;
    public int max_hp = 300;

    bool isCollidingWithHero = false;
    private float damageInterval = 0.8f;
    private float damageTimer = 0f;

    private float speed = 1.0f;
    private float timer = 0f;

    Collider2D enemyCollider;
    Animator anim;
    Rigidbody2D rb;
    bool isdead = false;

    void Start()
    {
        hp = max_hp;
        enemyCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isdead) return;

        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

        timer += Time.deltaTime;
        damageTimer += Time.deltaTime;

        if (hp <= 0 && !isdead)
        {
            hp = 0;
            Dead();
        }

        if (isCollidingWithHero && damageTimer >= damageInterval)
        {
            DealDamageToHero();
            damageTimer = 0f;
        }

        if (hp_bar != null)
        {
            hp_bar.transform.localScale = new Vector3((float)hp / max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("hero"))
        {
            speed = 0f;
            isCollidingWithHero = true;
            anim.SetBool("attack", true);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("hero"))
        {
            speed = 1.0f;
            isCollidingWithHero = false;
            damageTimer = 0f;
            anim.SetBool("attack", false);
        }
    }

    void DealDamageToHero()
    {
        if (!isCollidingWithHero) return;

        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int contactsCount = enemyCollider.GetContacts(contacts);

        for (int i = 0; i < contactsCount; i++)
        {
            GameObject heroObj = contacts[i].collider?.gameObject;
            if (heroObj != null && heroObj.CompareTag("hero"))
            {
                hero heroScript = heroObj.GetComponent<hero>();
                if (heroScript != null)
                {
                    heroScript.hp -= 15;
                }
            }
        }
    }

    void Dead()
    {
        isdead = true;
        rb.simulated = false;
        enemyCollider.enabled = false;
        anim.SetTrigger("dead");
    }

    public void Onenemy_deadAnimationEnd()
    {
        Destroy(gameObject);
    }
}
