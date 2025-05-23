using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private LayerMask triggerObjectLayer;
    public bool obtained = false;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public bool isTriggered()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, new Vector2(0, 1), 0.1f, triggerObjectLayer);
        return raycastHit.collider != null;
    }
    
    private void Update()
    {
        if (isTriggered())
        {
            obtained = true;
            Destroy(gameObject);
        }
    }
}



