using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadlyObject : MonoBehaviour
{
    [SerializeField] private LayerMask triggerObjectLayer;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update(){
        if (isTriggered() != null){
            if (isTriggered().tag == "Player"){
                isTriggered().GetComponent<PlayerMovement>().isDead = true;
            } else if (isTriggered().tag == "Button"){
                isTriggered().GetComponent<ButtonMovement>().isDead = true;
            }
        }
    }
    
    public GameObject isTriggered(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, new Vector2 (0,0), 0, triggerObjectLayer);
        if (raycastHit.collider == null)
        {
            return null;
        }
        else
        {
            return raycastHit.collider.gameObject;   
        }
    }
}