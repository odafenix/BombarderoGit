using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : Singleton<GameSceneManager>
{
    // Funciones para acceder a distintas escenas.
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

    // Función que nos permite salir del juego.
    public void ExitGame()
    {
      Application.Quit();
    }

}