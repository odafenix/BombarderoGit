using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainMenu : MonoBehaviour
{
    public void GoToMainMenuAction()
    {
        GameSceneManager.Instance.MainMenu();
        UnityGamingServices.AnalyticsManager.RegistrarNavegacion("MainMenu");
    }
}
