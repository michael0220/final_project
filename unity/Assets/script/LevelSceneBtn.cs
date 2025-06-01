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
        SoundEffectManager.Instance.PressLevelButton();
        PlayerPrefs.SetInt("ChooseLevel", 0);
        SceneManager.LoadScene(2);
    }

    public void StartLevel2()
    {
        SoundEffectManager.Instance.PressLevelButton();
        PlayerPrefs.SetInt("ChooseLevel", 1);
        SceneManager.LoadScene(3);
    }

    public void StartLevel3()
    {
        SoundEffectManager.Instance.PressLevelButton();
        PlayerPrefs.SetInt("ChooseLevel", 2);
        SceneManager.LoadScene(4);
    }
}
