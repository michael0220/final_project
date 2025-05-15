using System.Collections;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject victoryPanel;
    public GameObject enemy;

    void spawn_enemy(){
        int r = Random.Range(0, spawnpoints.Length);
        GameObject new_enemy = Instantiate(enemy, spawnpoints[r].position, Quaternion.identity);
    }

    void Start()
    {
        InvokeRepeating("spawn_enemy", 10, 7);
    }

    IEnumerator SpawnEnemy(){
        for(int i=0;i<5;i++){
            spawn_enemy();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(10);
        for(int i=0;i<6;i++){
            spawn_enemy();
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(10);
        for(int i=0;i<8;i++){
            spawn_enemy();
            yield return new WaitForSeconds(3);
        }
        Victory();
    }

    void Victory(){
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }
}
