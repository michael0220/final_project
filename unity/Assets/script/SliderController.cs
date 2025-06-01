using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider musicslider;
    public Slider sfxslider;

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            if (musicslider != null)
            {
                musicslider.value = AudioManager.Instance.GetMusicVolume();
                musicslider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
            }
            if (sfxslider != null)
            {
                sfxslider.value = AudioManager.Instance.GetSfxVolume();
                sfxslider.onValueChanged.AddListener(AudioManager.Instance.SetSfxVolume);
            }
        }
    }

    
}
