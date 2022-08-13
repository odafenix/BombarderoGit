using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : Singleton<GameSceneManager>
{
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Gameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ExitGame()
    {
      Application.Quit();
    }
}