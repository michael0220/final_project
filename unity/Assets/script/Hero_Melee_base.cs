using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;
using TMPro;

public class Hero_Melee_base : MonoBehaviour, IDamageable
{
    [SerializeField] private float max_hp = 400f;
    [SerializeField] private float basedamage = 35f;
    [SerializeField] private float damageInterval = 1.5f;

    public HeroType heroType;
    float damageTimer = 0f;
    public float hp;
    public GameObject hp_bar;
    bool isTriggerWithEnemy = false;
    private IDamageable targetEnemy;
    Collider2D heroCollider;
    Rigidbody2D rb;
    Animator anim;
    bool isdead = false;
    private float actualdamage;

    public TextMeshProUGUI levelText;

    void Start()
    {
        hp = 400;
        heroCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        int level = UpgradeManager.Instance.Getlevel(heroType);
        actualdamage = basedamage + (level - 1) * 10;

        max_hp += (level - 1) * 50;
        hp = max_hp;

        upgradeLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggerWithEnemy)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                AttackEnemy();
                damageTimer = 0f;
            }
        }
        if (hp <= 0 && !isdead)
        {
            hp = 0;
            Dead();
        }
        hp_bar.transform.localScale = new Vector3((float)((float)hp / (float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            isTriggerWithEnemy = true;
            targetEnemy = collision.GetComponent<IDamageable>();
            GetComponent<Animator>().SetBool("attack", true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            isTriggerWithEnemy = false;
            targetEnemy = null;
            damageTimer = 0f;
            GetComponent<Animator>().SetBool("attack", false);
        }
    }
    void AttackEnemy()
    {
        if (targetEnemy != null)
        {
            targetEnemy.takeDamage(actualdamage);
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
        heroCollider.enabled = false;
        anim.SetTrigger("dead");
    }

    public void Onhero_deadAnimationEnd()
    {
        Destroy(gameObject);
    }

    void upgradeLevelText()
    {
        int level = UpgradeManager.Instance.Getlevel(heroType);
        levelText.text = level.ToString();
    }
}
