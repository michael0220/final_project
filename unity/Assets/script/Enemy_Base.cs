using System.Collections;
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
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float currspeed;
    private enemy_spawner spawner;
    public float hp;
    public GameObject hp_bar;
    private bool isdead = false;
    public bool hasattacked = false;
    bool isTriggerWithHero;
    float damageTimer = 0f;
    private IDamageable targetHero;
    Animator anim;
    Rigidbody2D rb;
    Collider2D col;

    void Start()
    {
        spawner = FindAnyObjectByType<enemy_spawner>();
        hp = max_hp;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        if (RandomEventManager.isEnemySpeedUp)
        {
            applyRandomEvent();
        }
        currspeed = speed;
    }

    void Update()
    {
        if (isdead) return;
        transform.position -= new Vector3(currspeed * Time.deltaTime, 0, 0);

        if (isTriggerWithHero)
        {
            if (attype == AttackType.Melee)
            {
                damageTimer += Time.deltaTime;
                if (damageTimer >= damageInterval)
                {
                    AttackHero();
                    damageTimer = 0f;
                }
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
            targetHero = other.GetComponent<IDamageable>();
            currspeed = 0f;
            if (attype == AttackType.Melee)
            {
                isTriggerWithHero = true;
                GetComponent<Animator>().SetBool("attack", true);
            }
            else if (attype == AttackType.OneShot)
            {
                if (!hasattacked)
                {
                    isTriggerWithHero = true;
                    GetComponent<Animator>().SetBool("attack", true);
                    hasattacked = true;
                }
            }
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
            hasattacked = false;
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
        spawner.EnemyDead();
        isdead = true;
        rb.simulated = false;
        col.enabled = false;
        anim.SetTrigger("dead");
    }

    public void Onenemy_deadAnimationEnd()
    {
        Destroy(gameObject);
    }

    public void ApplyFreeze(float FreezeDamage, float Duration, float Interval)
    {
        StartCoroutine(FreezeEffect(FreezeDamage, Duration, Interval));
    }
    IEnumerator FreezeEffect(float FreezeDamage, float Duration, float Interval)
    {
        float originalSpeed = currspeed;
        currspeed = originalSpeed * 0.2f;
        Color originalColor = GetComponent<SpriteRenderer>().color;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        int count = Mathf.FloorToInt(Duration / Interval);

        for (int i = 0; i < count; i++)
        {
            takeDamage(FreezeDamage);
            sr.color = new Color(1f, 0.588f, 0.471f, 1f);
            yield return new WaitForSeconds(0.5f);
            sr.color = originalColor;
        }
        currspeed = originalSpeed;
    }

    void applyRandomEvent()
    {
        speed *= 1.5f;
    }
}

