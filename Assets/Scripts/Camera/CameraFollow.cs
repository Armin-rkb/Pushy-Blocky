using UnityEngine;

/// <summary>
/// Moves the object attached smoothly towards the target transform with a given offset.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    
    void FixedUpdate()
    {
        Vector3 targetPosition = targetTransform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
