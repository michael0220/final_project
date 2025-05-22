using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;

public class Hero_Tank_base : MonoBehaviour, IDamageable
{
    [SerializeField] private float max_hp = 400f;
    private float hp;
    public GameObject hp_bar;
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

    public void takeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0 && !isDead)
        {
            hp = 0;
            Dead();
        }
    }
    

    void Dead()
    {
        isDead = true;
        rb.simulated = false;
        potatoCollider.enabled = false;

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
