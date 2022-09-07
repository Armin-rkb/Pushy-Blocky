using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static event Action OnStartGame;
    public static event Action OnPauseGame;
    public static event Action OnResumeGame;
    public static event Action OnGameOver;

    void StartGame()
    {
        // Load level from scriptable object data.
        OnStartGame?.Invoke();
    }

    public void PauseGame()
    {
        // Pause the game, show UI with option to restart.
        OnPauseGame?.Invoke();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        // Hide pause UI and resume gameplay.
        OnResumeGame?.Invoke();
        Time.timeScale = 1;
    }

    void EndGame()
    {
        // Show end screen with option to play again, create json file with game stats.
        OnGameOver?.Invoke();
    }
}
