using UnityEngine;

public class SwitchPickup : Pickup
{
    protected override void PickupCollected()
    {
        Debug.Log("Change the Obstacles");
        Destroy(gameObject);
    }
}
