using System;

public class PositivePickup : Pickup
{
    public static event Action OnPositivePickup;

    protected override void PickupCollected()
    {
        OnPositivePickup?.Invoke();
        Destroy(gameObject);
    }
}
