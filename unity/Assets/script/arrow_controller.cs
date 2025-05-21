using UnityEngine;

public class arrow_controller : MonoBehaviour
{
    public float arrow_destroy_time = 0f;
    public float damage = 30f;
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
        targetEnemy.takeDamage(damage);
        Destroy(gameObject);
    }
}
