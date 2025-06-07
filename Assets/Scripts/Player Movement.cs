using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canJump;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask solidObjectLayer;
    [SerializeField] private GameObject socketLeft;
    [SerializeField] private GameObject socketRight;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;
    private Animator anim;

    private bool lefthmove = false;
    private bool righthmove = false;

    private bool leftdown = false;
    private bool rightdown = false;
    private bool beingdown = false;
    
    public bool isDead = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update(){
        bool buttonLeftInSocket = socketLeft.GetComponent<ButtonSocket>().buttonInSocket;
        bool buttonRightInSocket = socketRight.GetComponent<ButtonSocket>().buttonInSocket;
        int moveIndexLeft = socketLeft.GetComponent<ButtonSocket>().moveIndex;
        int moveIndexRight = socketRight.GetComponent<ButtonSocket>().moveIndex;

        if (buttonLeftInSocket){
            if (moveIndexLeft == 0){
                if (Input.GetKey(leftKey) || (buttonRightInSocket && moveIndexLeft == moveIndexRight && Input.GetKey(rightKey))){
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                    transform.localScale = new Vector3(-1,1,1);
                    lefthmove = true;
                } else {
                    body.linearVelocity = new Vector2(0,body.linearVelocity.y);
                    lefthmove = false;
                }
            } else if (moveIndexLeft == 1){
                if (Input.GetKey(leftKey) || (buttonRightInSocket && moveIndexLeft == moveIndexRight && Input.GetKey(rightKey))){
                    boxCollider2D.size = new Vector2(0.6f, 0.6f);
                    boxCollider2D.offset = new Vector2(0, -0.1f); 
                    leftdown = true;
                    beingdown = true;
                }  else {
                    leftdown = false;                
                }
            } else if (moveIndexLeft == 2){
                if (Input.GetKey(leftKey) || (buttonRightInSocket && moveIndexLeft == moveIndexRight && Input.GetKey(rightKey))){
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                    transform.localScale = new Vector3(1,1,1);
                    lefthmove = true;
                } else {
                    body.linearVelocity = new Vector2(0,body.linearVelocity.y);
                    lefthmove = false;
                }
            } else if (moveIndexLeft == 3){
                if ((Input.GetKey(leftKey) || (buttonRightInSocket && moveIndexLeft == moveIndexRight && Input.GetKey(rightKey))) && grounded() && canJump){
                    body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
                }
            }
        } else {
            lefthmove = false;
            leftdown = false;
        }

        if (buttonRightInSocket && !(buttonLeftInSocket && moveIndexLeft == moveIndexRight)){
            if (moveIndexRight == 0){
                if (Input.GetKey(rightKey)){
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                    transform.localScale = new Vector3(-1,1,1);
                    righthmove = true;
                } else {
                    body.linearVelocity = new Vector2(0,body.linearVelocity.y);
                    righthmove = false;
                }
            } else if (moveIndexRight == 1){
                if (Input.GetKey(rightKey)){
                    boxCollider2D.size = new Vector2(0.6f, 0.6f);
                    boxCollider2D.offset = new Vector2(0, -0.1f);
                    rightdown = true;
                    beingdown = true;
                } else {
                    rightdown = false;               
                }
            } else if (moveIndexRight == 2){
                if (Input.GetKey(rightKey)){
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                    transform.localScale = new Vector3(1,1,1);
                    righthmove = true;
                } else {
                    body.linearVelocity = new Vector2(0,body.linearVelocity.y);
                    righthmove = false;
                }
            } else if (moveIndexRight == 3){
                if (Input.GetKey(rightKey) && grounded() && canJump){
                    body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
                }
            }
        } else {
            righthmove = false;
            rightdown = false;
        }

        if (beingdown && !topped()){
            beingdown = false;
        }

        if (!beingdown && !(leftdown || rightdown)){
            boxCollider2D.size = new Vector2(0.6f, 1f);
            boxCollider2D.offset = new Vector2(0, 0);   
        }

        if (isDead){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
        
        anim.SetBool("move", lefthmove || righthmove);
        anim.SetBool("down", beingdown || leftdown || rightdown);
        anim.SetBool("grounded", grounded());
    }

    private bool grounded(){
        RaycastHit2D downHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, new Vector2 (0,-1), 0.2f, solidObjectLayer);
        return downHit.collider != null;
    }

    private bool topped(){
        RaycastHit2D upHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, new Vector2 (0,1), 0.3f, solidObjectLayer);
        return upHit.collider != null;
    }
}