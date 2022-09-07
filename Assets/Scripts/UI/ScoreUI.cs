using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
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
    }

    void UpdateScore()
    {
        scoreUI.text = "Score: " + currentScore;
    }

    private void OnEnable()
    {
        PointPickup.OnPointCollected += IncreaseScore;
    }

    private void OnDisable()
    {
        PointPickup.OnPointCollected -= IncreaseScore;
    }

}
