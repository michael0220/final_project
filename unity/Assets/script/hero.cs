using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;


public class hero : MonoBehaviour
{
    public float speed;
    void Start()
    {
        speed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(speed*Time.deltaTime*60, 0, 0);
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "enemy"){
            speed = 0;
        }
    }
    void OCollisionExit2D(Collision2D other)
    {
        speed = 0;
    }
}
