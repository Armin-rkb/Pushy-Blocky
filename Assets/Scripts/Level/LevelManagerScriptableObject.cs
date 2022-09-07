using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelManagerScriptableObject", order = 1)]
public class LevelManagerScriptableObject : ScriptableObject
{
    public GameObject[] levelChunkPrefab;
}
