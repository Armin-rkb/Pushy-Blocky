using UnityEngine;

public class PointPickup : Pickup
{
    [SerializeField]
    private int scoreAmount = 1;

    protected override void PickupCollected()
    {
        Debug.Log("Score Collected: " + scoreAmount);
        Destroy(gameObject);
    }
}
