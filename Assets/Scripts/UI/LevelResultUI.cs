using UnityEngine;

public class LevelResultUI : MonoBehaviour
{
    [SerializeField]
    private GameObject WinScreen;
    [SerializeField]
    private GameObject LoseScreen;

    public void ShowWinScreen()
    {
        WinScreen.SetActive(true);
    }

    private void ShowLoseScreen()
    {
        LoseScreen.SetActive(true);
    }

    public void HideWinScreen()
    {
        WinScreen.SetActive(false);
    }

    public void HideLoseScreen()
    {
        LoseScreen.SetActive(false);
    }

    private void OnEnable()
    {
        GameController.OnGameWon += ShowWinScreen;
        GameController.OnGameOver += ShowLoseScreen;
    }

    private void OnDisable()
    {
        GameController.OnGameWon -= ShowWinScreen;
        GameController.OnGameOver -= ShowLoseScreen;
    }
}
