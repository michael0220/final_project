using UnityEngine;

public class arrow_controller : MonoBehaviour
{ 

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(5.0f, 0);  // 直接給一個右邊的速度
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
