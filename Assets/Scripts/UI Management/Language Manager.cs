using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;
    private const string languageKey = "languageKey";

    Dictionary<string, string> texts = new Dictionary<string, string> { };

    private void Awake()
    {
        Instance = this;
    }

    public void SetLanguage(int value)
    {
        PlayerPrefs.SetInt(languageKey, value);
        PlayerPrefs.Save();

        if (GetLanguage() == 0)
        {
            texts.Clear();
            texts.Add("Select Level", "Select Level");
            texts.Add("Settings", "Settings");
            texts.Add("Credits", "Credits");
            texts.Add("Back", "Back");
            texts.Add("Language", "Language");
            texts.Add("Help", "Help");
            texts.Add("Resume", "Resume");
            texts.Add("Restart", "Restart");
            texts.Add("Home", "Home");
        }
        else if (GetLanguage() == 1)
        {
            texts.Clear();
            texts.Add("Select Level", "Pilih Level");
            texts.Add("Settings", "Pengaturan");
            texts.Add("Credits", "Kredit");
            texts.Add("Back", "Kembali");
            texts.Add("Language", "Bahasa");
            texts.Add("Help", "Bantuan");
            texts.Add("Resume", "Lanjutkan");
            texts.Add("Restart", "Mulai Ulang");
            texts.Add("Home", "Home");
        }
    }

    public int GetLanguage()
    {
        return PlayerPrefs.GetInt(languageKey, 0);
    }

    public string GetText(string textCode)
    {
        return texts[textCode];
    }
}
