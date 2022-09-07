using UnityEngine;

public class SelfCollisionIgnore : MonoBehaviour
{
    [SerializeField]
    private Collider mainCollider;
    [SerializeField]
    private Collider ObjectBlockCollider;

    private void Awake()
    {
        Physics.IgnoreCollision(mainCollider, ObjectBlockCollider, true);
    }
}
