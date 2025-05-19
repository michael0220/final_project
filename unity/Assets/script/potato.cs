using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;

public class potato : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public int hp;
    public int max_hp = 400;
    public GameObject hp_bar;

    private float damageTimer = 0f;
    private float damageInterval = 1.5f;
    private bool isTakingDamage = false;
    private Collider2D potatoCollider;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isDead = false;
    public Sprite deadSprite;
    private SpriteRenderer sr;
    void Start()
    {
        hp = max_hp;
        potatoCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTakingDamage)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0f;
            }
        }

        if (hp <= 0 && !isDead)
        {
            hp = 0;
            Dead();
        }
        if (hp_bar != null)
        {
            hp_bar.transform.localScale = new Vector3((float)hp / max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            isTakingDamage = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            isTakingDamage = false;
            damageTimer = 0f;
        }
    }

    

    void Dead()
    {
        isDead = true;
    rb.simulated = false;
    potatoCollider.enabled = false;

    // 換成死亡圖片
    if (deadSprite != null && sr != null)
    {
        sr.sprite = deadSprite;
        Destroy(hp_bar);
    }

    if (hp_bar != null)
    {
        Destroy(hp_bar);
    }
    
    Invoke("DestroyPotato", 2f);
    }

    void DestroyPotato()
    {
    Destroy(gameObject);
    }
}
