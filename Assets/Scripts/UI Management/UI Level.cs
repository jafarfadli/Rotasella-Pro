using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    [SerializeField] GameObject[] allStages;
    [SerializeField] Button[] allLevels;
    private int currentStage = 0;

    public void firstStage()
    {
        currentStage = 0;
        foreach (GameObject stage in allStages)
        {
            stage.SetActive(false);
        }
        allStages[0].SetActive(true);

        unlockLevel();
    }

    public void nextStage()
    {
        allStages[currentStage].SetActive(false);
        currentStage = currentStage < allStages.Length - 1 ? currentStage + 1 : 0;

        allStages[currentStage].SetActive(true);

        unlockLevel();
    }

    public void previousStage()
    {
        allStages[currentStage].SetActive(false);
        currentStage = currentStage > 0 ? currentStage - 1 : allStages.Length - 1;

        allStages[currentStage].SetActive(true);

        unlockLevel();
    }

    public void unlockLevel(){
        int currentProgress = ProgressManager.Instance.GetProgress();
        for (int i = currentStage * 10; i < (currentStage + 1) * 10 && i < allLevels.Length; i++) {
            if (i <= currentProgress)
            {
                allLevels[i].interactable = true;
            }
            else
            {
                allLevels[i].interactable = false;
            }
        }
    }
}