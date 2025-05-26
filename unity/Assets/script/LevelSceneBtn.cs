using UnityEngine;

public class LevelSceneBtn : MonoBehaviour
{
    public string sceneName;

    public void LoadScene()
    {
        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.TransitionToScene(sceneName);
        }
    }
}
