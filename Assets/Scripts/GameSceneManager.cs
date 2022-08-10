using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<Tipo> : MonoBehaviour where Tipo : MonoBehaviour
{
    public static Tipo Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as Tipo;
            Object.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}

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