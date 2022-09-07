using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private string playerTag = "Player";

    private void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.CompareTag(playerTag)) return;

        PickupCollected();
    }

    protected abstract void PickupCollected();
}
