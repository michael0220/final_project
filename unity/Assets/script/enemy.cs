using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp;
    public GameObject hp_bar;
    public int max_hp=300;

    bool isCollidingWithHero = false;
    private float damageInterval = 0.8f;
    private float damageTimer = 0f;

    public float timer=0;
    
    private float speed = 1.0f;

    Collider2D enemyCollider;

    void Start()
    {
        hp = 300;
        enemyCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position -= new Vector3(speed*Time.deltaTime, 0, 0);
        timer += Time.deltaTime;
        if(hp<=0)
        {
            hp=0;
            Destroy(this.gameObject);
        }
        if(isCollidingWithHero && damageTimer>=damageInterval){
            DealDamageToHero();
            damageTimer = 0f;
        }
        damageTimer += Time.deltaTime;
        hp_bar.transform.localScale = new Vector3((float)((float)hp/(float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("hero")){
            speed = 0f;
            isCollidingWithHero = true;
        }
    }
    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("hero")){
            speed = 1.0f;
            isCollidingWithHero = false;
        }
    }

    void DealDamageToHero(){
        if(!isCollidingWithHero) return;

        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int contactsCount = enemyCollider.GetContacts(contacts);

        for(int i=0;i<contactsCount;i++){
            GameObject heroObj = contacts[i].collider != null ? contacts[i].collider.gameObject : null;
            if(heroObj != null && heroObj.CompareTag("hero")){
                hero heroScript = heroObj.GetComponent<hero>();
                if(heroScript!=null){
                    heroScript.hp -= 15;
                }
            }
        }
    }
}
