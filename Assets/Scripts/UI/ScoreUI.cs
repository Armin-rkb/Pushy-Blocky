using TMPro;
using System;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static event Action<int> OnScoreUpdated;

    private int currentScore;
    
    [SerializeField]
    private TMP_Text scoreUI;

    void ResetScore()
    {
        currentScore = 0;
        UpdateScore();
    }

    void IncreaseScore(int val)
    {
        currentScore += val;
        UpdateScore();

        OnScoreUpdated?.Invoke(currentScore);
    }

    void UpdateScore()
    {
        scoreUI.text = "Score: " + currentScore;
    }

    private void OnEnable()
    {
        GameController.OnStartGame += ResetScore;
        PointPickup.OnPointCollected += IncreaseScore;
    }

    private void OnDisable()
    {
        GameController.OnStartGame -= ResetScore;
        PointPickup.OnPointCollected -= IncreaseScore;
    }

}
