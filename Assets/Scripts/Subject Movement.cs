using UnityEngine;

public class SubjectMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canJump;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask solidObjectLayer;
    [SerializeField] private GameObject socket;
    [SerializeField] private KeyCode key;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;
    private Animator anim;

    private bool move = false;
    private bool down = false;
    private bool beingdown = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        bool buttonInSocket = socket.GetComponent<ButtonSocket>().buttonInSocket;
        int moveIndex = socket.GetComponent<ButtonSocket>().moveIndex;

        if (buttonInSocket)
        {
            if (moveIndex == 0) {
                if (Input.GetKey(key)) {
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                    transform.localScale = new Vector3(-1, 1, 1);
                    move = true;
                } else{
                    body.linearVelocity = new Vector2(0, body.linearVelocity.y);
                    move = false;
                }
            } else if (moveIndex == 1) {
                if (Input.GetKey(key))
                {
                    boxCollider2D.size = new Vector2(0.6f, 0.6f);
                    boxCollider2D.offset = new Vector2(0, -0.1f);
                    down = true;
                    beingdown = true;
                } else {
                    down = false;
                }
            } else if (moveIndex == 2) {
                if (Input.GetKey(key))
                {
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                    transform.localScale = new Vector3(1, 1, 1);
                    move = true;
                } else {
                    body.linearVelocity = new Vector2(0, body.linearVelocity.y);
                    move = false;
                }
            } else if (moveIndex == 3) {
                if (Input.GetKey(key) && grounded() && canJump) {
                    body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
                }
            }
        } else {
            move = false;
            down = false;
        }

        if (beingdown && !topped()){
            beingdown = false;
        }

        if (!beingdown && !down){
            boxCollider2D.size = new Vector2(0.6f, 1f);
            boxCollider2D.offset = new Vector2(0, 0);   
        }

        anim.SetBool("move", move);
        anim.SetBool("down", down);
        anim.SetBool("jump", !grounded());
    }

    private bool grounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, new Vector2(0, -1), 0.2f, solidObjectLayer);
        return raycastHit.collider != null;
    }
    
    private bool topped(){
        RaycastHit2D upHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, new Vector2 (0,1), 0.3f, solidObjectLayer);
        return upHit.collider != null;
    }
}