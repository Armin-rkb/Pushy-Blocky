using System.Collections;
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
        pauseButton.SetActive(false);
    }    
    
    private void ShowPauseScreen()
    {
        if (!pauseButton || !pauseScreen) return;

        pauseScreen.SetActive(true);
        pauseButton.SetActive(true);
    }

    private void OnEnable()
    {
        GameController.OnPauseGame += HidePauseScreen;
        GameController.OnPauseGame += ShowPauseScreen;
    }

    private void OnDisable()
    {
        GameController.OnPauseGame -= HidePauseScreen;
        GameController.OnPauseGame -= ShowPauseScreen;
    }
}
