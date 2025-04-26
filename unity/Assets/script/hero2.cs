using UnityEngine;

public class hero2 : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform launchpoint;
    public float lauchforce = 10f;
    public float delaytime = 3.0f;

    public float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>delaytime){
            GameObject newArrow = Instantiate(arrowPrefab, launchpoint.position, Quaternion.identity);
            timer = 0;
        }
    }
}
