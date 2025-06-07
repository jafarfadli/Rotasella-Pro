using TMPro;
using UnityEngine;

public class LanguageDropdown : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;

    void Start()
    {
        languageDropdown.value = LanguageManager.Instance.GetLanguage();
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
        LanguageManager.Instance.SetLanguage(languageDropdown.value);
    }

    public void OnLanguageChanged(int index)
    {
        LanguageManager.Instance.SetLanguage(index);
    }
}