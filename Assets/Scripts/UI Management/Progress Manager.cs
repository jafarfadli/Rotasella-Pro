using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;
    private const string progressKey = "progress";

    private void Awake()
    {
        Instance = this;
    }

    public void UpProgress()
{
        int currentProgress = GetProgress();
        PlayerPrefs.SetInt(progressKey, currentProgress + 1);
        PlayerPrefs.Save();
    }

    public int GetProgress()
    {
        return PlayerPrefs.GetInt(progressKey, 0);
    }



}