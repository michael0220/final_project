using UnityEngine;

public class hero2 : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject hp_bar;
    public Transform launchpoint;
    public float launchforce = 6f;
    public float delaytime = 1.0f;
    public float hp;
    public float max_hp=200f;
    public float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        hp = 200f;
    }
    void Update()
    {
        Debug.Log("Hero2 HP: " + hp);
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
        if(hp<=0){
            hp=0;
            Destroy(this.gameObject);
        }
        hp_bar.transform.localScale = new Vector3((float)((float)hp/(float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
}
