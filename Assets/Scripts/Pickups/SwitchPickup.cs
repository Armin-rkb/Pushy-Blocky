using System;

public class SwitchPickup : Pickup
{
    public static event Action OnObstacleSwitch;

    protected override void PickupCollected()
    {
        OnObstacleSwitch?.Invoke();
        Destroy(gameObject);
    }
}
