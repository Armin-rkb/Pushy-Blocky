using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static event Action<GameObject> OnPlayerSpawned;

    [SerializeField]
    private GameObject playerPrefab;

    private void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, Vector3.up, Quaternion.identity);
        OnPlayerSpawned?.Invoke(player);
    }

    private void OnEnable()
    {
        LevelManager.OnLevelBuild += SpawnPlayer;
    }

    private void OnDisable()
    {
        LevelManager.OnLevelBuild -= SpawnPlayer;
    }
}
