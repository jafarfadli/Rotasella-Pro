using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    [SerializeField] GameObject[] mainSockets;
    public GameObject buttonSocket = null;
    private Collider2D Collider2D;
    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer SpriteRenderer;
    public bool isDragging = false;
    private Vector2 offset;

    public bool isDead = false;
    private void Awake()
    {
        Collider2D = GetComponent<Collider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, LayerMask.GetMask("Button"));
            if (hit.collider == Collider2D)
            {
                isDragging = true;
                offset = (Vector2)transform.position - mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Collider2D.enabled = false;
            transform.position = (Vector3)(mousePosition + offset);

            SpriteRenderer.sortingOrder = 10;
        }
        else
        {
            Collider2D.enabled = true;
            SpriteRenderer.sortingOrder = 5;
        }

        if (buttonSocket != null || isDragging)
        {
            Collider2D.isTrigger = true;
            Rigidbody2D.gravityScale = 0;
            Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            Collider2D.isTrigger = false;
            if (Rigidbody2D.gravityScale == 0)
            {
                Rigidbody2D.gravityScale = 1;
                Rigidbody2D.constraints = RigidbodyConstraints2D.None;
            }
        }

        if (buttonSocket != null && !isDragging)
        {
            transform.position = buttonSocket.transform.position;
            adjustAngle();
        }

        if (isDead)
        {
            isDead = false;
            if (!mainSockets[0].GetComponent<ButtonSocket>().buttonInSocket)
            {
                transform.position = mainSockets[0].transform.position;
            }
            else
            {
                transform.position = mainSockets[1].transform.position;
            }
        }
    }

    private void adjustAngle(){
        float rotationZ = transform.eulerAngles.z;
        int targetRotationZ = Mathf.FloorToInt((rotationZ + 45) % 360 / 90) * 90;
        transform.rotation = Quaternion.Euler(0, 0, targetRotationZ);
    }
}



