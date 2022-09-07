using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    public static event Action<int> OnAddScore;

    [SerializeField]
    private TextMesh scoreUI;

    private int currentScore;

    void ResetScore()
    {

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
}
