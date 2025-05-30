using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{
    enemy_spawner enemySpawner;
    public GameObject hp_bar;
    public float max_hp = 1000f;
    public float curr_hp;
    public Transform spawnplace;
    public float speed = 1f;
    public float spawnInterval = 8f;
    private int lastSpawnPoint = -1;
    private bool spawnEnabled = true;
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private int spawnmin = 4;
    [SerializeField] private int spawnMAX = 6;
    [SerializeField] private GameObject[] enemyPrefab;
    Animator anim;
    Rigidbody2D rb;
    Collider2D colid;

    void Start()
    {
        curr_hp = max_hp;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        colid = GetComponent<Collider2D>();
        StartCoroutine(SpawnCycle());
    }

    void Update()
    {
        if (curr_hp <= 0)
        {
            curr_hp = 0;
            Dead();
        }
        else if (curr_hp <= max_hp * 0.1f)
        {
            spawnEnabled = false;
        }
        hp_bar.transform.localScale = new Vector3((float)curr_hp / max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    IEnumerator SpawnCycle()
    {
        while (spawnEnabled)
        {
            int nextpoint = GetNextSpawnPoint();
            Vector3 targetpos = new Vector3(transform.position.x, spawnpoints[nextpoint].position.y, 0);
            float offset = spawnplace.position.y - transform.position.y;
            Vector3 adjust = new Vector3(transform.position.x, targetpos.y - offset, 0);
            while (Vector2.Distance(transform.position, adjust) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, adjust, speed * Time.deltaTime);
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
            Instantiate(enemytospawn, spawnplace.position, Quaternion.identity);

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

    public void takeDamage(float amount)
    {
        curr_hp -= amount;
    }

    void Dead()
    {
        rb.simulated = false;
        colid.enabled = false;
        anim.SetTrigger("destory");
        enemySpawner.EnemyDead();
    }

    public void OnBossAnimEnd()
    {
        Destroy(gameObject);
    }
    
}
