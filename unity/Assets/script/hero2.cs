using UnityEngine;

public class hero2 : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform launchpoint;
    public float lauchforce = 10f;
    public float delaytime = 2.0f;

    public float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arrowPrefab.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            Instantiate(arrowPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
