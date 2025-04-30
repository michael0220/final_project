using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1f;

    public void StartTransition(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeGroup.alpha = timer / fadeDuration;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
