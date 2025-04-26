using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp;
    public int max_hp=150;
    private bool iscollision;
    public float timer=0;
    private float interval = 1;
    public GameObject hp_bar;
    void Start()
    {
        hp = 150;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if((timer>=interval) && iscollision){
            hp-=20;
            timer = 0;
        }
        if(hp<=0)
        {
            hp=0;
            Destroy(this.gameObject);
        }
        hp_bar.transform.localScale = new Vector3((float)((float)hp/(float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "hero"){
            iscollision = true;
        }
    }
    void OnCollisionExit2D(Collision2D other) 
    {
        iscollision = false;
    }
}
