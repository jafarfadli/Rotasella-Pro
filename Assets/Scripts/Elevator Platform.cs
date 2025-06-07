using UnityEngine;

class ElevatorPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] tracks;
    [SerializeField] private float speed = 2f;
    private int trackIndex = 0;
    private bool triggered = false;
    private bool changed = false;

    private void Update(){
        if (transform.position == tracks[trackIndex].position || changed){
            changed = false;
            if (triggered && trackIndex != tracks.Length - 1){
                trackIndex += 1;
            }
            if (!triggered && trackIndex != 0){
                trackIndex -= 1;
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, tracks[trackIndex].position, speed * Time.deltaTime);
        }
    }

    public void forward(){
        if (!triggered){
            triggered = true;
            changed = true;
        }
    }

    public void backward(){
        if (triggered){
            triggered = false;
            changed = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        string tag = other.gameObject.tag;
        if (tag == "Player" || tag == "Subject" || tag == "Button"){
            if (gameObject.activeInHierarchy)
            {
                other.transform.SetParent(transform, true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other){
        string tag = other.gameObject.tag;
        if (tag == "Player" || tag == "Subject" || tag == "Button"){
            if (other.transform.parent == transform)
            {
                other.transform.SetParent(null, true);
            }
        }
    }
}