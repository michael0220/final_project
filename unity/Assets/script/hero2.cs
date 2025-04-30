using UnityEngine;

public class hero2 : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform launchpoint;
    public float lauchforce = 10f;
    public float delaytime = 1.0f;

    public float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       timer += Time.deltaTime;

        if (timer > delaytime)
        {
            // 實例化箭矢
            GameObject newArrow = Instantiate(arrowPrefab, launchpoint.position, Quaternion.identity);

            // 讓箭矢向右飛（根據 hero2 的方向）
            Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.right * lauchforce;
            }

            timer = 0;
        }
    }
    
}
