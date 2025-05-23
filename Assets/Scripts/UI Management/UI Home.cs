using UnityEngine;

public class UIHome : MonoBehaviour
{
    [SerializeField] GameObject mainUI;
    void Awake()
    {
        GetComponent<UIManager>().setUI(mainUI);
        Time.timeScale = 1;
    }
}

