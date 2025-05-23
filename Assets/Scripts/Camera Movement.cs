using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    void Update(){
        Vector2 camPosition = new Vector3 (Mathf.FloorToInt((player.position.x + 12) / 24) * 24, Mathf.FloorToInt((player.position.y + 7) / 14) * 14, -10);
        transform.position = transform.position + (Vector3)(camPosition - (Vector2)transform.position) * speed * Time.deltaTime;
    }
}

