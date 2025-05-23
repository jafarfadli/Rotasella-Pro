using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    public Slider sfxSlider;

    void Start()
    {
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();
        sfxSlider.onValueChanged.AddListener(OnVolumeChanged);
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);
    }
    
    void OnVolumeChanged(float newValue)
    {
        AudioManager.Instance.SetSFXVolume(newValue);
    }
}