using UnityEngine;
using UnityEngine.XR;
using TMPro;
using Unity.VisualScripting;

public class Hero_Ranged_base : MonoBehaviour, IDamageable
{
    [SerializeField] private float max_hp = 200f;
    [SerializeField] private float base_delaytime = 3.0f;
    [SerializeField] private float launchforce = 6f;
    public HeroType heroType;
    public GameObject arrowPrefab;
    public GameObject hands, gun;
    public GameObject hp_bar;
    public Transform launchpoint;
    Collider2D hero2Collider;
    Rigidbody2D rb;
    Animator anim;
    float actual_delaytime;
    public float hp;
    public float timer = 0f;
    bool isdead = false;

    public TextMeshProUGUI levelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 200f;
        hero2Collider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        int level = UpgradeManager.Instance.Getlevel(heroType);

        actual_delaytime = base_delaytime - (level - 1) * 0.5f;

        max_hp += (level - 1) * 50;
        hp = max_hp;

        upgradeLevelText();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > actual_delaytime)
        {
            GameObject newArrow = Instantiate(arrowPrefab, launchpoint.position, Quaternion.identity);

            Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.right * launchforce;
            }
            timer = 0;
        }
        if (hp <= 0 && !isdead)
        {
            hp = 0;
            Dead();
        }
        hp_bar.transform.localScale = new Vector3((float)((float)hp / (float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    public void takeDamage(float amount)
    {
        hp -= amount;
    }

    public void Dead()
    {
        isdead = true;

        rb.simulated = false;
        hero2Collider.enabled = false;

        hands.SetActive(false);
        gun.SetActive(false);

        anim.SetTrigger("dead");
    }

    public void Onhero2_deadAnimationEnd()
    {
        Destroy(gameObject);
    }

    void upgradeLevelText()
    {
        int level = UpgradeManager.Instance.Getlevel(heroType);
        levelText.text = level.ToString();
    }
}
