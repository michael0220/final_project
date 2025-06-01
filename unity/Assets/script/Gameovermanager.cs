using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameovermanager : MonoBehaviour
{
    public Gameovermanager gameovermanager;
    public GameObject winPanel;
    public GameObject losePanel;
    private bool allenemyspawn = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!allenemyspawn)
        {
            return;
        }
        if (AllEnemyDead())
        {
            gameovermanager.ShowWinPanel();
        }
    }

    public void OnAllEnemySpawn()
    {
        allenemyspawn = true;
    }

    public void OnEnmeyReachEdge()
    {
        gameovermanager.ShowLosePanel();
    }

    public bool AllEnemyDead()
    {
        return GameObject.FindGameObjectsWithTag("enemy").Length == 0;
    }

    public void ShowWinPanel()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 2);
        if (unlockedLevel <= currentIndex)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentIndex + 1);
            PlayerPrefs.Save();
        }
    }

    public void ShowLosePanel()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }

    public void ExitToMap()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene currscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currscene.name);
    }

    public void GoToNextLevel()
    {
        Time.timeScale = 1f;
        int currindex = SceneManager.GetActiveScene().buildIndex;
        int nextindex = currindex + 1;
        PlayerPrefs.SetInt("ChooseLevel", nextindex - 2);
        PlayerPrefs.Save();
        if (nextindex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextindex);
        }
        else
        {
            //可設計破完關的東西
        }
    }

}
