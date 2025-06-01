using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance;
    //private AudioSource sfxSource;
    public AudioClip levelbutton;
    public AudioClip entrybutton;
    public AudioClip panelbutton;
    public AudioClip BuyHeroButton;
    public AudioClip enemy1attack;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //sfxSource = AudioManager.Instance != null ? AudioManager.Instance.sfxsource : gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null && AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxsource.PlayOneShot(clip);
        }
    }

    public void PressLevelButton()
    {
        PlaySound(levelbutton);
    }

    public void PressEntryButton()
    {
        PlaySound(entrybutton);
    }

    public void PressPanelButton()
    {
        PlaySound(panelbutton);
    }

    public void PressBuyHero()
    {
        PlaySound(BuyHeroButton);
    }

    public void enemy1Attack()
    {
        PlaySound(enemy1attack);
    }
}
