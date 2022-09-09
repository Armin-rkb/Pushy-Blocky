using System.IO;
using UnityEngine;

public class JsonFileCreator : MonoBehaviour
{
    private LevelStats endStats = new LevelStats();

    private int startTime;
    private int endTime;

    void GetTimeStats()
    {
        endTime = System.DateTime.Now.Second;
        endStats.timePlayed = endTime - startTime;
        endStats.timeJsonMade = System.DateTime.Now.Ticks;
    }

    private void SaveToJson()
    {
        GetTimeStats();
        string levelStats = JsonUtility.ToJson(endStats);

        File.WriteAllText(Application.persistentDataPath + "/LevelStats.json", levelStats);
    }

    private void ResetStats()
    {
        endStats = new LevelStats();
        endStats.gameName = Application.productName;
        startTime = System.DateTime.Now.Second;
        endTime = 0;
    }

    void SetLatestScore(int val)
    {
        endStats.score = val;
    }

    private void OnEnable()
    {
        ScoreUI.OnScoreUpdated += SetLatestScore;
        GameController.OnStartGame += ResetStats;
        GameController.OnGameWon += SaveToJson;
        GameController.OnGameOver += SaveToJson;
    }

    private void OnDisable()
    {
        ScoreUI.OnScoreUpdated -= SetLatestScore;
        GameController.OnStartGame -= ResetStats;
        GameController.OnGameWon -= SaveToJson;
        GameController.OnGameOver -= SaveToJson;
    }
}
