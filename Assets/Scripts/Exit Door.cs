using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private Key key;
    [SerializeField] private GameObject playerExit;
    [SerializeField] string nextScene;

    [SerializeField] int currentLevel;
    private Animator anim;
    private float delay = 0;

    private bool exit = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerExit.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && key.obtained)
        {
            playerExit.SetActive(true);
            collision.gameObject.SetActive(false);
            exit = true;

            anim.SetBool("win", true);
        }
    }

    void Update()
    {
        if (exit)
        {
            delay += Time.deltaTime;
        }
        if (delay > 1)
        {
            int currentProgress = ProgressManager.Instance.GetProgress();
            if (currentProgress < currentLevel)
            {
                ProgressManager.Instance.UpProgress();
            }
            
            SceneManager.LoadScene(nextScene);
        }
    }
}
