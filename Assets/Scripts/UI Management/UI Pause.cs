using UnityEngine;

public class UIPause : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    bool isPaused = false;

    private void Awake()
    {
        GetComponent<UIManager>().clearUI();
        Time.timeScale = 1;
    }

    void Update(){
        if (!isPaused) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                GetComponent<UIManager>().clearUI();
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }
}
