using UnityEngine;

public class hero2 : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform launchpoint;
    public float launchforce = 6f;
    public float delaytime = 1.0f;

    private float timer = 0f;
    public int hp=350;
    public int max_hp = 350;
    public GameObject hp_bar;
    void Start()
    {
        hp = max_hp;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delaytime)
        {
            GameObject newArrow = Instantiate(arrowPrefab, launchpoint.position, Quaternion.identity);

            Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.right * launchforce;
            }

            timer = 0;
        }
        if (hp_bar != null)
        {
        float scale = Mathf.Clamp01((float)hp / max_hp); // 限制 0~1 避免負值
        hp_bar.transform.localScale = new Vector3(scale, 1, 1); // 只縮 X
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
