using UnityEngine;

public class ball_controller : MonoBehaviour
{
    public float speed = 0.5f;
    private bool hasExploded = false;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasExploded)
        {
            return;
        }
        if (other.CompareTag("hero"))
        {
            hasExploded = true;
            rb.linearVelocity = Vector2.zero;
            anim.SetTrigger("explode");
            //Destroy(other.gameObject);
            IDamageable hero = other.GetComponent<IDamageable>();
            if (hero != null)
            {
                hero.takeDamage(999);
            }
        }
    }

    public void OnExplosionEnd()
    {
        Destroy(gameObject);
    }
}
