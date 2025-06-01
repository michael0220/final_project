using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneBtn : MonoBehaviour
{
    //public string sceneName;

    //public void LoadScene()
    //{
    //    if (SceneTransitionManager.Instance != null)
    //    {
    //        SceneTransitionManager.Instance.TransitionToScene(sceneName);
    //    }
    //}

    public void StartLevel1()
    {
        PlayerPrefs.SetInt("ChooseLevel", 0);
        SceneManager.LoadScene(2);
    }

    public void StartLevel2()
    {
        PlayerPrefs.SetInt("ChooseLevel", 1);
        SceneManager.LoadScene(3);
    }

    public void StartLevel3()
    {
        PlayerPrefs.SetInt("ChooseLevel", 2);
        SceneManager.LoadScene(4);
    }
}
