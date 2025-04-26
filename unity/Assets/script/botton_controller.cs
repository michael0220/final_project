using UnityEngine;

public class botton_controller : MonoBehaviour
{
    public GameObject hero_prefab;

    public void spawn_hero()
    {
        Instantiate(hero_prefab, new Vector3(-4.0f, -1.3f, 0), Quaternion.identity);
    }   
}
