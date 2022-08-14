using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneController : MonoBehaviour
{
    public void GoToCreditsScreen()
    {
        GameSceneManager.Instance.Credits();
        UnityGamingServices.AnalyticsManager.RegistrarNavegacion("CreditsScreen");
    }

    public void GoToGameplay()
    {
        GameSceneManager.Instance.Gameplay();
        UnityGamingServices.AnalyticsManager.RegistrarNavegacion("GameplayScreen");
    }

    public void QuitGame()
    {
        GameSceneManager.Instance.ExitGame();
        
    }

    public void GoToMainMenuAction()
    {
        GameSceneManager.Instance.MainMenu();
        UnityGamingServices.AnalyticsManager.RegistrarNavegacion("MainMenuScreen");
        
    }
}
