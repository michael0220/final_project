using UnityEngine;
using UnityEngine.SceneManagement;

public class Musicmanager : MonoBehaviour
{
    private static Musicmanager instance;
    private AudioSource audioSource;
    private string currentmusicname = "";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource = AudioManager.Instance != null ? AudioManager.Instance.musicsource : gameObject.AddComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string musictoplay = GetMusicName(scene.buildIndex);
        if (musictoplay != currentmusicname)
        {
            currentmusicname = musictoplay;
            AudioClip clip = Resources.Load<AudioClip>("Audio/" + musictoplay);
            if (clip != null)
            {
                audioSource.clip = clip;
                //audioSource.volume = AudioManager.Instance != null ? AudioManager.Instance.musicsource.volume : 1f;
                audioSource.Play();
            }
        }
    }

    string GetMusicName(int index)
    {
        if (index == 0 || index == 1)
        {
            return "backgroundmusic";
        }
        else if (index == 2 || index == 3)
        {
            return "backgroundmusic_level12";
        }
        else if (index == 4)
        {
            return "backgroundmusic_level3";
        }
        else
        {
            return "";
        }
    }
}
