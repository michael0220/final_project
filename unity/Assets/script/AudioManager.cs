using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicsource;
    public AudioSource sfxsource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            if (musicsource == null)
            {
                musicsource = gameObject.AddComponent<AudioSource>();
            }
            if (sfxsource == null)
            {
                sfxsource = gameObject.AddComponent<AudioSource>();
            }
            musicsource.loop = true;
            musicsource.playOnAwake = false;
            sfxsource.playOnAwake = false;
            musicsource.volume = PlayerPrefs.GetFloat("MusicV", 1f);
            sfxsource.volume = PlayerPrefs.GetFloat("SfxV", 1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
        PlayerPrefs.SetFloat("MusicV", volume);
    }

    public void SetSfxVolume(float volume)
    {
        sfxsource.volume = volume;
        PlayerPrefs.SetFloat("SfxV", volume);
    }

    public float GetMusicVolume() => musicsource.volume;
    public float GetSfxVolume() => sfxsource.volume;
}
