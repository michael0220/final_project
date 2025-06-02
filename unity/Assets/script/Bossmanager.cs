using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bossmanager : MonoBehaviour
{
    enemy_spawner enemySpawner;
    public GameObject bossprefab;
    public GameObject hp_bar;
    public Gameovermanager gameovermanager;
    public float failx = -7.1f;
    public Transform bossspawnpoint;
    public float speed = 1f;
    public float spawnInterval = 8f;
    private int lastSpawnPoint = -1;
    private bool spawnEnabled = true;
    private bool haveLost = false;
    private Boss boss;
    private List<GameObject> activeEnemy = new List<GameObject>();
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private int spawnmin = 4;
    [SerializeField] private int spawnMAX = 6;
    [SerializeField] private GameObject[] enemyPrefab;


    void Start()
    {
        GameObject bossObj = Instantiate(bossprefab, bossspawnpoint.position, Quaternion.identity);
        boss = bossObj.GetComponent<Boss>();
        StartCoroutine(WaitandSpawn());
    }

    IEnumerator WaitandSpawn()
    {
        yield return new WaitForSeconds(4.5f);
        spawnEnabled = true;
        StartCoroutine(SpawnCycle());
    }

    void Update()
    {
        if (haveLost)
        {
            return;
        }
        CheckifOverEdge();
        if (boss.curr_hp <= boss.max_hp * 0.1f)
        {
            spawnEnabled = false;
            gameovermanager.OnAllEnemySpawn();
        }
        hp_bar.transform.localScale = new Vector3((float)boss.curr_hp / boss.max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    IEnumerator SpawnCycle()
    {
        while (spawnEnabled)
        {
            int nextpoint = GetNextSpawnPoint();
            Vector3 targetpos = new Vector3(boss.transform.position.x, spawnpoints[nextpoint].position.y, 0);
            float offset = boss.spawnplace.position.y - boss.transform.position.y;
            Vector3 adjust = new Vector3(boss.transform.position.x, targetpos.y - offset, 0);
            while (Vector2.Distance(boss.transform.position, adjust) > 0.1f)
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, adjust, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(3);
            SpawnEnemies();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SpawnEnemies()
    {
        int enemyNum = Random.Range(spawnmin, spawnMAX + 1);
        for (int i = 0; i < enemyNum; i++)
        {
            int enemytype = Random.Range(0, enemyPrefab.Length);
            GameObject enemytospawn = enemyPrefab[enemytype];
            GameObject enemy = Instantiate(enemytospawn, boss.spawnplace.position, Quaternion.identity);
            activeEnemy.Add(enemy);
        }
    }

    int GetNextSpawnPoint()
    {
        int nextp;
        do
        {
            nextp = Random.Range(0, spawnpoints.Length);
        } while (nextp == lastSpawnPoint);
        lastSpawnPoint = nextp;
        return nextp;
    }

    private void CheckifOverEdge()
    {
        for (int i = activeEnemy.Count - 1; i >= 0; i--)
        {
            GameObject enemy = activeEnemy[i];
            if (enemy == null)
            {
                activeEnemy.RemoveAt(i);
                continue;
            }
            if (enemy.transform.position.x < failx)
            {
                Debug.Log("敵人超過界線: " + enemy.transform.position.x);
                haveLost = true;
                Destroy(enemy);
                gameovermanager.ShowLosePanel();
                break;
            }
        }
    }
    
}

