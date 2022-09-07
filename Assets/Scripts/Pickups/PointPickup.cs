using System;
using UnityEngine;

public class PointPickup : Pickup
{
    public static event Action<int> OnPointCollected;

    [SerializeField]
    private int scoreAmount = 1;

    protected override void PickupCollected()
    {
        OnPointCollected?.Invoke(scoreAmount);
        Destroy(gameObject);
    }
}
