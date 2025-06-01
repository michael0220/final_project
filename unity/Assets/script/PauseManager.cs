using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausepanel;
    private bool isPause = false;

    public void PressPause()
    {
        SoundEffectManager.Instance.PressPanelButton();
        isPause = !isPause;
        pausepanel.SetActive(isPause);
        Time.timeScale = isPause ? 0 : 1;
    }

    public void ResumGame()
    {
        SoundEffectManager.Instance.PressPanelButton();
        isPause = false;
        pausepanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
