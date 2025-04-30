using UnityEngine;

public class hero2 : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform launchpoint;
    public float launchforce = 6f;
    public float delaytime = 1.0f;

    private float timer = 0f;
    public int hp;
    public int max_hp = 350;
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
    }
}
