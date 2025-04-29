using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject enemy;

    void spawn_enemy(){
        int r = Random.Range(0, spawnpoints.Length);
        GameObject new_enemy = Instantiate(enemy, spawnpoints[r].position, Quaternion.identity);
    }

    void Start()
    {
        //InvokeRepeating("spawn_enemy", 2, 7);
    }
}
