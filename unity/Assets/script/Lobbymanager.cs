using UnityEngine;

public class lobbymanager : MonoBehaviour
{
    public GameObject settingpanel;

    public void PressSettingButton()
    {
        SoundEffectManager.Instance.PressPanelButton();
        settingpanel.SetActive(true);
    }

    public void PressBackButton()
    {
        SoundEffectManager.Instance.PressPanelButton();
        settingpanel.SetActive(false);
    }
}
