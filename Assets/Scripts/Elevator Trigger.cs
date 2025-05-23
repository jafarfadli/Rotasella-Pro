using UnityEngine;

class ElevatorTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask triggerObjectLayer;
    [SerializeField] private ElevatorPlatform elevatorPlatform;
    private BoxCollider2D boxCollider2D;
    private Vector3 originalScale;
    private Vector3 originalPosition;

    private void Awake(){
        boxCollider2D = GetComponent<BoxCollider2D>();
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    private void Update(){
        if (isTriggered()){
            elevatorPlatform.forward();

            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);
            transform.position = new Vector3(originalPosition.x, originalPosition.y - originalScale.y * 0.25f, originalPosition.z);
        } else{
            elevatorPlatform.backward();

            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
            transform.position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z);
        }
    }
    public bool isTriggered(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, new Vector2 (0,1), 0.1f, triggerObjectLayer);
        return raycastHit.collider != null;
    }
}