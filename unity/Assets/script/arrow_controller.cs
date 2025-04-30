using UnityEngine;

public class arrow_controller : MonoBehaviour
{ 
    public float arrow_destroy_time;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(6.0f, 0); 
        }

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

    // Update is called once per frame
    void Update()
    {
        arrow_destroy_time += Time.deltaTime;
        if(arrow_destroy_time>=3) Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy")){
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            if(enemyScript != null){
                enemyScript.hp -= 30;
                GetComponent<Collider2D>().enabled = false;
                Destroy(this.gameObject);
            }
            
        }
    }
}
