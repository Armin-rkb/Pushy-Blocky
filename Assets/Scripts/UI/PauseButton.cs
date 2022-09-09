using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseButton;

    [SerializeField]
    private GameObject pauseScreen;

    private void HidePauseScreen()
    {
        if (!pauseButton || !pauseScreen) return;

        pauseScreen.SetActive(false);
        ShowPauseButton();
    }    
    
    private void ShowPauseScreen()
    {
        if (!pauseButton || !pauseScreen) return;

        pauseScreen.SetActive(true);
        HidePauseButton();
    }

    private void HidePauseButton()
    {
        pauseButton.SetActive(false);
    }

    private void ShowPauseButton()
    {
        pauseButton.SetActive(true);
    }

    private void OnEnable()
    {
        GameController.OnStartGame += ShowPauseButton;
        GameController.OnGameWon += HidePauseButton;
        GameController.OnGameOver += HidePauseButton;
        GameController.OnPauseGame += HidePauseScreen;
        GameController.OnPauseGame += ShowPauseScreen;
    }

    private void OnDisable()
    {
        GameController.OnStartGame -= ShowPauseButton;
        GameController.OnGameWon -= HidePauseButton;
        GameController.OnGameOver -= HidePauseButton;
        GameController.OnPauseGame -= HidePauseScreen;
        GameController.OnPauseGame -= ShowPauseScreen;
    }
}
