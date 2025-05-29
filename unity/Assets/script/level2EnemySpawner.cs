using System.Collections;
using UnityEngine;
using TMPro;

public class level2EnemySpawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject victoryPanel;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject wavebar;
    public TextMeshProUGUI wavetext, waveDisplay;

    public int wave1Enemy, Wave2Enemy, Wave3Enemy, Wave4Enemy;
    int restEnemy, totalEnemy;

    void spawn_enemy(GameObject enemyPrefab){
        int r = Random.Range(0, spawnpoints.Length);
        Instantiate(enemyPrefab, spawnpoints[r].position, Quaternion.identity);
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        SetTotalEnemy(wave1Enemy);
        UpdateWaveText(restEnemy);
        waveDisplay.text = "Wave 1";
        yield return new WaitForSeconds(15);
        for (int i = wave1Enemy; i > 0; i--)
        {
            spawn_enemy(enemy);
            yield return new WaitForSeconds(5);
        }
        yield return new WaitUntil(()=>restEnemy<=0);
        waveDisplay.text = "Wave 2";
        SetTotalEnemy(Wave2Enemy);
        UpdateWaveText(restEnemy);
        yield return new WaitForSeconds(10);
        for (int i = Wave2Enemy; i > 0; i--)
        {
            spawn_enemy(enemy);
            if (i==(Wave2Enemy-2))
            {
                spawn_enemy(enemy2);
            }
            if (i==(Wave2Enemy-3))
            {
                spawn_enemy(enemy2);
                spawn_enemy(enemy3);
            }
            yield return new WaitForSeconds(5);
        }
        yield return new WaitUntil(()=>restEnemy<=0);
        waveDisplay.text = "Wave 3";
        SetTotalEnemy(Wave3Enemy);
        UpdateWaveText(restEnemy);
        yield return new WaitForSeconds(10);
        for (int i = Wave3Enemy; i > 0; i--)
        {
            spawn_enemy(enemy);
            if (i==(Wave3Enemy-2))
            {
                for (int j = 0; j < 2; j++)
                {
                    spawn_enemy(enemy3);
                    spawn_enemy(enemy2);
                    yield return new WaitForSeconds(3);
                }
            }
            yield return new WaitForSeconds(3);
        }
        yield return new WaitUntil(() => restEnemy <= 0);
        waveDisplay.text = "Wave 4";
        SetTotalEnemy(Wave4Enemy);
        UpdateWaveText(restEnemy);
        yield return new WaitForSeconds(10);
        for (int i = Wave4Enemy; i > 0; i--)
        {
            spawn_enemy(enemy);
            spawn_enemy(enemy2);
            spawn_enemy(enemy3);
            yield return new WaitForSeconds(1);
        }
        Victory();
    }
    public void SetTotalEnemy(int total)
    {
        totalEnemy = total;
        restEnemy = total;
        UpdateWaveText(total);
    }

    public void EnemyDead()
    {
        restEnemy -= 1;
        UpdateWaveText(restEnemy);
    }

    public void UpdateWaveText(int restEnemy)
    {
        float ratio = (float)restEnemy / totalEnemy;
        wavebar.transform.localScale = new Vector3(ratio, wavebar.transform.localScale.y, wavebar.transform.localScale.z);
        wavetext.text = restEnemy + " / " + totalEnemy;
    }
    void Victory(){
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }
}
