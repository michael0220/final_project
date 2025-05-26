using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public CanvasGroup transitionAnim;
    public static SceneTransitionManager Instance;
    public Animator transitionAnimator;
    public float transitionTime = 1f;
    void Start()
    {
        SetCanvasGroup(transitionAnim, false);
    }
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
    void SetCanvasGroup(CanvasGroup group, bool visible)
    {
        group.alpha = visible ? 1 : 0;
        group.blocksRaycasts = visible;
        group.interactable = visible;
    }
    IEnumerator LoadSceneRoutine(string sceneName)
    {
        transitionAnimator.SetBool("Loading", true);
        SetCanvasGroup(transitionAnim, true);
        yield return new WaitForSeconds(transitionTime);
        transitionAnimator.SetBool("Loading", false);
        SceneManager.LoadScene(sceneName);
        yield return null;
        SetCanvasGroup(transitionAnim, false);
    }
}
