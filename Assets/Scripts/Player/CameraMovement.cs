using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] [Range(0f, 1f)] float cameraSmoothing;

    void FixedUpdate()
    {
        Vector3 targetPosition = new(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSmoothing);
    }
}
