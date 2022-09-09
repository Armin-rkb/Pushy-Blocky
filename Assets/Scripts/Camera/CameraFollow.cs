using UnityEngine;

/// <summary>
/// Moves the object attached smoothly towards the target transform with a given offset.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private Transform targetTransform;

    void FixedUpdate()
    {
        if (!targetTransform) return;

        Vector3 targetPosition = targetTransform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void SetTargetTransform(GameObject obj)
    {
        targetTransform = obj.transform;
    }

    private void OnEnable()
    {
        PlayerSpawner.OnPlayerSpawned += SetTargetTransform;
    }

    private void OnDisable()
    {
        PlayerSpawner.OnPlayerSpawned -= SetTargetTransform;
    }
}
