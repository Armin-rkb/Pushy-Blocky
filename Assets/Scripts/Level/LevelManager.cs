using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private LevelManagerScriptableObject levelData;

    // Event for when the level has finished building.
    public static event Action OnLevelBuild;

    private void Start()
    {
        BuildLevel();
    }

    /// <summary>
    /// Gets the list of chunks to spawn in order.
    /// </summary>
    void BuildLevel()
    {
        Renderer chunkRenderer;
        Vector3 nextPosition = Vector3.zero;

        for (int i = 0; i < levelData.levelChunkPrefab.Length; i++)
        {
            GameObject currentChunk = Instantiate(levelData.levelChunkPrefab[i], nextPosition, Quaternion.identity);
            
            chunkRenderer = currentChunk.GetComponentInChildren<Renderer>();
            if (chunkRenderer)
            {
                nextPosition.z += chunkRenderer.bounds.size.z;
            }
            else
            {
                Debug.LogError("Incorrect chunk in list!");
            }
        }

        OnLevelBuild?.Invoke();
    }
}
