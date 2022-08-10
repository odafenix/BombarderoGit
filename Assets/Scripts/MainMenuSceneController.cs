using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : MonoBehaviour
{
    public void GoToCreditsScreen()
    {
        GameSceneManager.Instance.Credits();
    }

    public void GoToGameplay()
    {
        GameSceneManager.Instance.Gameplay();
    }

    public void QuitGame()
    {
        GameSceneManager.Instance.ExitGame();
    }
}
