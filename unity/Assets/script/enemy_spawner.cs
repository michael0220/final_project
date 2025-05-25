using System.Collections;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject victoryPanel;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;

    void spawn_enemy(GameObject enemyPrefab){
        int r = Random.Range(0, spawnpoints.Length);
        Instantiate(enemyPrefab, spawnpoints[r].position, Quaternion.identity);
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        //InvokeRepeating("spawn_enemy", 10, 7);
    }

    IEnumerator SpawnEnemy(){
        yield return new WaitForSeconds(15);
        for (int i = 0; i < 5; i++)
        {
            spawn_enemy(enemy);
            yield return new WaitForSeconds(5);
        }
        yield return new WaitForSeconds(10);
        for(int i=0;i<6;i++){
            spawn_enemy(enemy);
            if (i < 3)
            {
                spawn_enemy(enemy2);
            }
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(10);
        for(int i=0;i<8;i++){
            spawn_enemy(enemy);
            if (i < 7)
            {
                spawn_enemy(enemy2);
            }
            if (i == 4) spawn_enemy(enemy3);
            yield return new WaitForSeconds(3);
        }
        Victory();
    }

    void Victory(){
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }
}
