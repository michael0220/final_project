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
        rb.linearVelocity = Vector2.left * speed;
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
            Destroy(other.gameObject);
        }
    }

    public void OnExplosionEnd()
    {
        Destroy(gameObject);
    }
}
