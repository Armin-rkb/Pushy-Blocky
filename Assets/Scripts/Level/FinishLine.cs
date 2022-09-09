using System;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public static event Action OnFinishReached;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag(Tags.playerTag))
        {
            OnFinishReached?.Invoke();
        }
    }
}
