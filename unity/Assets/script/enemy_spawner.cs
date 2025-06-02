using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class enemy_spawner : MonoBehaviour
{
    public GameObject PlotPanel;
    public float typingSpeed = 0.05f;

    public TextMeshProUGUI PlotText;
    private string currentText;


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
        Debug.Log("spawn_enemy 呼叫！產生了 " + enemyPrefab.name);
        activeEnemy.Add(newenemy);
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        ChooseLevel = PlayerPrefs.GetInt("ChooseLevel", 0);
        StartCoroutine(WaitRandomEndThenSpawn());
        RandomEventManager.isShowing = false;
        Debug.Log("enemy_spawner Start 被呼叫了！");
    }

    IEnumerator WaitRandomEndThenSpawn()
    {
        while (RandomEventManager.isShowing)
        {
            yield return null;
        }
        if (RandomEventManager.isMoreEnemy)
        {
            applyRandomEvent();
        }
        StartCoroutine(SpawnEnemy());
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
        Debug.Log("SpawnEnemy 開始執行了！");
        if (ChooseLevel == 0)
        {
            SetTotalEnemy(wave1Enemy);
            UpdateWaveText(restEnemy);
            waveDisplay.text = "WAVE 1";
            StartCoroutine(ColorChangeRoutine());
            yield return new WaitForSeconds(15);
            showPlotText("Oh... am I dreaming? Why is it so noisy...? Oh my gosh, a bunch of ugly freaks just stormed into the spaceship! Who are you guys!? Stop right there!");
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
            showPlotText("Wait, who are you...? Never mind, there’s no time to ask—more strange creatures are rushing in!");
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

            waveDisplay.text = "Final Wave";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave3Enemy + 9;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            showPlotText("Why are there more and more of them?\nIt looks like they're coming from the cockpit!Hurry, take them down! We can’t let them take over the cockpit!");
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
        else if (ChooseLevel == 1)
        {
            SetTotalEnemy(wave1Enemy);
            UpdateWaveText(restEnemy);
            waveDisplay.text = "WAVE 1";
            StartCoroutine(ColorChangeRoutine());
            yield return new WaitForSeconds(15);
            showPlotText("Damn it, they’ve taken the cockpit too... The mothership warned us—someone opened a space-time rift. There’s no time. We have to stop them, now!");
            for (int i = wave1Enemy; i > 0; i--)
            {
                spawn_enemy(enemy);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitUntil(() => restEnemy <= 0);

            waveDisplay.text = "WAVE 2";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave2Enemy + 3;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            showPlotText("Good, we’re still in control for now. Maybe we can defeat them!");
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
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitUntil(() => restEnemy <= 0);

            waveDisplay.text = "WAVE 3";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave3Enemy + 4;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            showPlotText("(A flash of light appears outside the cockpit window.)");
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
                        yield return new WaitForSeconds(2f);
                    }
                }
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitUntil(() => restEnemy <= 0);

            waveDisplay.text = "Final Wave";
            StartCoroutine(ColorChangeRoutine());
            RealEnemyNum = Wave4Enemy * 3;
            SetTotalEnemy(RealEnemyNum);
            UpdateWaveText(restEnemy);
            yield return new WaitForSeconds(10);
            showPlotText("That light outside is blinding... It feels like... I don’t know.\nTake care of them quickly so we can go check it out!");
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
        else if (ChooseLevel == 2)
        {
            yield return new WaitForSeconds(8);
            showPlotText("Oh my god, what is that hideous giant spaceship!?\nThat must be their leader! Let’s take them down and save the world!!");
            for (int i = wave1Enemy; i > 0; i--)
            {
                Debug.Log("ChooseLevel==2 開始執行了！");
                spawn_enemy(enemy);
                yield return new WaitForSeconds(0.5f);
                spawn_enemy(enemy2);
                yield return new WaitForSeconds(0.5f);
                spawn_enemy(enemy3);
                yield return new WaitForSeconds(5f);
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
        Color black = new Color(0f, 0f, 0f, 0.7961f);
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

    void showPlotText(string text)
    {
        PlotPanel.SetActive(true);
        StartCoroutine(showText(text));
    }
    IEnumerator showText(string text)
    {
        PlotText.text = "";
        currentText = "";

        for (int i = 0; i < text.Length; i++)
        {
            currentText += text[i];
            PlotText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(3f);
        PlotPanel.SetActive(false);
    }




}
