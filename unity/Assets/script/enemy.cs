using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp;
    public int max_hp=300;
    public float timer=0;
    public GameObject hp_bar;
    private float speed = 1.0f;
    void Start()
    {
        hp = 300;
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
        hp_bar.transform.localScale = new Vector3((float)((float)hp/(float)max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("hero")) speed = 0;
    }
    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("hero")) speed = 1.0f;
    }
}
