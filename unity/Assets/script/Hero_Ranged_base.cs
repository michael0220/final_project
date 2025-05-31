using UnityEngine;
using UnityEngine.XR;
using TMPro;
using Unity.VisualScripting;

public class Hero_Ranged_base : Hero_Base, IDamageable
{
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
    public float timer = 0f;
    public TextMeshProUGUI levelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hero2Collider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        int level = UpgradeManager.Instance.Getlevel(heroType);
        if (RandomEventManager.isHero3Stronger && heroType == HeroType.hero3)
        {
            applyRandomEvent();
        }

        actual_delaytime = base_delaytime - (level - 1) * 0.5f;

        maxHp += (level - 1) * 50;
        currHp = maxHp;

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
        UpdateHp();
        hp_bar.transform.localScale = new Vector3((float)(currHp / maxHp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    public void takeDamage(float amount)
    {
        currHp -= amount;
    }

    protected override void Dead()
    {
        isdead = true;

        rb.simulated = false;
        hero2Collider.enabled = false;

        hands.SetActive(false);
        gun.SetActive(false);

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

    void applyRandomEvent()
    {
        maxHp *= 1.5f;
        base_delaytime *= 0.8f;
    }
}
