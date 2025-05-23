using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public Slider musicSlider;

    void Start()
    {
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
        musicSlider.onValueChanged.AddListener(OnVolumeChanged);
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
    }
    
    void OnVolumeChanged(float newValue)
    {
        AudioManager.Instance.SetMusicVolume(newValue);
    }
}