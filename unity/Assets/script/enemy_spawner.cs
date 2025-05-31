using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;

public class enemy_spawner : MonoBehaviour
{
    private int RealEnemyNum;
    public int ChooseLevel;
    public int repeat = 3;
    public float fadetime = 0.3f;
    public float failx = -7.1f;
    public Gameovermanager gameovermanager;
    public Transform[] spawnpoints;
    //public GameObject victoryPanel;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject wavebar;
    public TextMeshProUGUI wavetext, waveDisplay;

    public int wave1Enemy, Wave2Enemy, Wave3Enemy, Wave4Enemy;
    int restEnemy, totalEnemy;
    private List<GameObject> activeEnemy = new List<GameObject>();
    private bool haveLost = false;

    void spawn_enemy(GameObject enemyPrefab)
    {
        int r = Random.Range(0, spawnpoints.Length);
        GameObject newenemy = Instantiate(enemyPrefab, spawnpoints[r].position, Quaternion.identity);
        activeEnemy.Add(newenemy);
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        if (RandomEventManager.isMoreEnemy)
        {
            applyRandomEvent();
        }
    }

    void applyRandomEvent()
    {
        wave1Enemy += 2;
        Wave2Enemy += 2;
        Wave3Enemy += 2;
        Wave4Enemy += 2;
    }

    void Update()
    {
        if (haveLost)
        {
            return;
        }
        CheckifOverEdge();
    }

    IEnumerator SpawnEnemy()
    {
        if (ChooseLevel == 1)
        {
            SetTotalEnemy(wave1Enemy);
            UpdateWaveText(restEnemy);
            waveDisplay.text = "WAVE 1";
            StartCoroutine(ColorChangeRoutine());
            yield return new WaitForSeconds(15);
            for (int i = wave1Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                yield return new WaitForSeconds(1);
            }
            yield return new WaitUntil(() => restEnemy <= 0);

            waveDisplay.text = "WAVE 2";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave2Enemy + 3;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            for (int i = Wave2Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                if (i < 3)
                {
                    spawn_enemy(enemy2);
                    yield return new WaitForSeconds(0.5f);
                }
                if (i < 2)
                {
                    spawn_enemy(enemy3);
                }
                yield return new WaitForSeconds(1);
            }
            yield return new WaitUntil(() => restEnemy <= 0);

            waveDisplay.text = "WAVE 3";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave3Enemy + 9;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            for (int i = Wave3Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                if (i < 7)
                {
                    spawn_enemy(enemy2);
                    yield return new WaitForSeconds(0.5f);
                }
                if (i < 4)
                {
                    spawn_enemy(enemy3);
                }
                yield return new WaitForSeconds(3);
            }
            gameovermanager.OnAllEnemySpawn();
            yield return new WaitUntil(() => restEnemy <= 0);

        }
        else if (ChooseLevel == 2)
        {
            SetTotalEnemy(wave1Enemy);
            UpdateWaveText(restEnemy);
            waveDisplay.text = "WAVE 1";
            StartCoroutine(ColorChangeRoutine());
            yield return new WaitForSeconds(15);
            for (int i = wave1Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                yield return new WaitForSeconds(5);
            }
            yield return new WaitUntil(() => restEnemy <= 0);

            waveDisplay.text = "WAVE 2";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave2Enemy + 3;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            for (int i = Wave2Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                if (i == (Wave2Enemy - 2))
                {
                    spawn_enemy(enemy2);
                }
                if (i == (Wave2Enemy - 3))
                {
                    spawn_enemy(enemy2);
                    yield return new WaitForSeconds(0.5f);
                    spawn_enemy(enemy3);
                }
                yield return new WaitForSeconds(5);
            }
            yield return new WaitUntil(() => restEnemy <= 0);

            waveDisplay.text = "WAVE 3";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave3Enemy + 4;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            for (int i = Wave3Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                if (i == (Wave3Enemy - 2))
                {
                    for (int j = 0; j < 2; j++)
                    {
                        spawn_enemy(enemy3);
                        yield return new WaitForSeconds(0.5f);
                        spawn_enemy(enemy2);
                        yield return new WaitForSeconds(3);
                    }
                }
                yield return new WaitForSeconds(3);
            }
            yield return new WaitUntil(() => restEnemy <= 0);

            waveDisplay.text = "WAVE 4";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave4Enemy * 3;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            for (int i = Wave4Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                spawn_enemy(enemy2);
                spawn_enemy(enemy3);
                yield return new WaitForSeconds(1);
            }
            gameovermanager.OnAllEnemySpawn();
            yield return new WaitUntil(() => restEnemy <= 0);
        }
        else if (ChooseLevel == 3)
        {
            yield return new WaitForSeconds(8);
            for (int i = wave1Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                yield return new WaitForSeconds(0.5f);
                spawn_enemy(enemy2);
                yield return new WaitForSeconds(0.5f);
                spawn_enemy(enemy3);
                yield return new WaitForSeconds(3.5f);
            }
        }
        //Victory();
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
                //Debug.Log("敵人超過界線: " + enemy.transform.position.x);
                haveLost = true;
                Destroy(enemy);
                gameovermanager.ShowLosePanel();
                break;
            }
        }
    }

    IEnumerator ColorChangeRoutine()
    {
        Color red = new Color(1f, 0f, 0f, 0.7961f);
        Color black = new Color(0f, 0f, 0f, 0.7961f) ;
        for (int i = 0; i < repeat; i++)
        {
            yield return StartCoroutine(ColorChange(red, black, fadetime));
            yield return StartCoroutine(ColorChange(black, red, fadetime));
        }
    }

    IEnumerator ColorChange(Color fromcolor, Color tocolor, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            float t = timer / duration;
            waveDisplay.color = Color.Lerp(fromcolor, tocolor, t);
            timer += Time.deltaTime;
            yield return null;
        }
        waveDisplay.color = tocolor;
    }
    //void Victory(){
    //    Time.timeScale = 0f;
    //    victoryPanel.SetActive(true);
    //}
}
