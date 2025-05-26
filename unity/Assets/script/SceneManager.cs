using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    public Animator transitionAnimator;
    public float transitionTime = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    IEnumerator LoadSceneRoutine(string sceneName)
    {
        transitionAnimator.SetTrigger("Loading");
        yield return new WaitForSeconds(transitionTime);
        transitionAnimator.ResetTrigger("Loading");
        SceneManager.LoadScene(sceneName);
    }
}
