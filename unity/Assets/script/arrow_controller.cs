using UnityEngine;

public class arrow_controller : MonoBehaviour
{
    public float arrow_destroy_time = 0f;
    public int damage = 30;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(6.0f, 0); // 默認速度
        }

        // 避免撞到 hero2
        GameObject hero = GameObject.FindGameObjectWithTag("hero");
        if (hero != null)
        {
            Collider2D heroCollider = hero.GetComponent<Collider2D>();
            Collider2D arrowCollider = GetComponent<Collider2D>();
            if (heroCollider != null && arrowCollider != null)
            {
                Physics2D.IgnoreCollision(heroCollider, arrowCollider);
            }
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemy enemyScript = collision.gameObject.GetComponent<enemy>();
            if (enemyScript != null)
            {
                enemyScript.hp -= damage;
                GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
