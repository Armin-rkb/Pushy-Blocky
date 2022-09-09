using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if (!coll.gameObject.CompareTag(Tags.playerTag)) return;

        PickupCollected();
    }

    protected abstract void PickupCollected();
}
