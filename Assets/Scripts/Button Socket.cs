using UnityEngine;

public class ButtonSocket : MonoBehaviour{

    [SerializeField] GameObject startingButton;
    public bool buttonInSocket = false;
    public int moveIndex = -1;
    private GameObject currentButton = null;

    private void Awake()
    {
        if (startingButton != null){
            currentButton = startingButton;
            buttonInSocket = true;
            currentButton.GetComponent<ButtonMovement>().buttonSocket = gameObject;
        
            float rotationZ = currentButton.transform.rotation.eulerAngles.z;
            moveIndex = Mathf.FloorToInt((rotationZ + 45) % 360 / 90);
        }
    }

    void Update()
    {
        Collider2D other = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Button"));
        if (other != null){
            if (!other.gameObject.GetComponent<ButtonMovement>().isDragging 
            && other.gameObject.GetComponent<ButtonMovement>().buttonSocket == null 
            && !buttonInSocket){
                currentButton = other.gameObject;
                buttonInSocket = true;
                currentButton.GetComponent<ButtonMovement>().buttonSocket = gameObject;
            
                float rotationZ = currentButton.transform.rotation.eulerAngles.z;
                moveIndex = Mathf.FloorToInt((rotationZ + 45) % 360 / 90);
            }
        } else if (currentButton != null){
            buttonInSocket = false;
            
            currentButton.GetComponent<ButtonMovement>().buttonSocket = null;
            moveIndex = -1;
            currentButton = null;
        }
    }
}