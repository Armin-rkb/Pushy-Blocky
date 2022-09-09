using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private LevelManagerScriptableObject levelData;

    private List<GameObject> loadedChunkList = new List<GameObject>();

    private bool hasBuiltLevel = false;

    // Event for when the level has finished building.
    public static event Action OnLevelBuild;

    private void Start()
    {
        //BuildLevel();
    }

    /// <summary>
    /// Gets the list of chunks to spawn in order.
    /// </summary>
    void BuildLevel()
    {
        if (hasBuiltLevel && loadedChunkList.Any())
        {
            CleanUpLoadedChunks();
        }

        Renderer chunkRenderer;
        Vector3 nextPosition = Vector3.zero;

        for (int i = 0; i < levelData.levelChunkPrefab.Length; i++)
        {
            GameObject currentChunk = Instantiate(levelData.levelChunkPrefab[i], nextPosition, Quaternion.identity);
            loadedChunkList.Add(currentChunk);
            
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

        hasBuiltLevel = true;
        OnLevelBuild?.Invoke();
    }

    private void CleanUpLoadedChunks()
    {
        foreach (GameObject chunk in loadedChunkList)
        {
            Destroy(chunk);
        }
        hasBuiltLevel = false;
        loadedChunkList.Clear();
    }

    private void OnEnable()
    {
        GameController.OnStartGame += BuildLevel;
    }

    private void OnDisable()
    {
        GameController.OnStartGame -= BuildLevel;
    }
}
