using UnityEngine;
using UnityEngine.XR;

public class hero2 : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject hands, gun;
    public GameObject hp_bar;
    public Transform launchpoint;
    Collider2D hero2Collider;
    Rigidbody2D rb;
    Animator anim;
    public float launchforce = 6f;
    public float delaytime = 1.0f;
    public float hp;
    public float max_hp=200f;
    public float timer = 0f;
    bool isdead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        hp = 200f;
        hero2Collider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        if(hp<=0&&!isdead){
            hp=0;
            Dead();
        }
        hp_bar.transform.localScale = new Vector3((float)((float)hp/(float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    public void Dead(){
        isdead = true;

        rb.simulated = false;
        hero2Collider.enabled = false;

        hands.SetActive(false);
        gun.SetActive(false);

        anim.SetTrigger("dead");
    }

    public void Onhero2_deadAnimationEnd(){
        Destroy(gameObject);
    }
}
