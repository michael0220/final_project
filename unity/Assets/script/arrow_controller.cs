using UnityEngine;

public class arrow_controller : MonoBehaviour
{
    public float arrow_destroy_time = 0f;
    public int damage = 30;

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
        if (other.CompareTag("enemy"))
        {
            Enemy enemyScript = other.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.hp -= damage;
                Destroy(gameObject);
            }
        }
    }
}
