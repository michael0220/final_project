using UnityEngine;

public class botton_controller : MonoBehaviour
{
    public GameObject hero_prefab;
    public GameObject hero2_prefab;
    public GameObject enemy_prefab;

    public void spawn_hero()
    {
        Instantiate(hero_prefab, new Vector3(-4.0f, -1.3f, 0), Quaternion.identity);
    }
    public void spawn_hero2(){
        Instantiate(hero2_prefab, new Vector3(-4.0f, -1.3f, 0), Quaternion.identity);
    }
    public void spawn_enemy(){
        Instantiate(enemy_prefab, new Vector3(5.0f, -1.3f, 0), Quaternion.identity);
    }
}
