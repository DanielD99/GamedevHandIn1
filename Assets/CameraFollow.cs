using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the ball's transform
    public Vector3 offset = new Vector3(3, 4, 2); // Adjust the camera position offset

    void Update()
    {
        // Ensure the target (ball) exists
        if (target != null)
        {
            // Set the camera's position relative to the ball
            transform.position = target.position + offset;
        }
    }
}
