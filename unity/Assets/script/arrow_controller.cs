using UnityEngine;

public class arrow_controller : MonoBehaviour
{
    [SerializeField] float basedDamage;
    private float actualDamage;
    public HeroType heroType;
    public float arrow_destroy_time = 0f;
    private IDamageable targetEnemy;

    void Start()
    {
        GameObject hero = GameObject.FindGameObjectWithTag("hero");
        if (hero != null)
        {
            Collider2D heroCol = hero.GetComponent<Collider2D>();
            Collider2D arrowCol = GetComponent<Collider2D>();
            if (heroCol && arrowCol)
                Physics2D.IgnoreCollision(heroCol, arrowCol);
        }
        int level = UpgradeManager.Instance.Getlevel(heroType);
        if (RandomEventManager.isHero2WithPowerfulBullet && heroType==HeroType.hero2)
        {
            applyRandomEvent();
        }
        actualDamage = basedDamage * (1 + (level - 1) * 0.8f);
    }

    void Update()
    {
        arrow_destroy_time += Time.deltaTime;
        if (arrow_destroy_time >= 3f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            targetEnemy = collision.GetComponent<IDamageable>();
            if (targetEnemy != null) attackEnemy();
        }
    }
    void attackEnemy()
    {
        targetEnemy.takeDamage(actualDamage);
        Destroy(gameObject);
    }

    void applyRandomEvent()
    {
        basedDamage += 10f;
    }
}
