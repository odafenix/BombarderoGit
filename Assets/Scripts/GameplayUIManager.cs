using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSingleton<Tipo> : MonoBehaviour where Tipo : MonoBehaviour
{
    public static Tipo Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as Tipo;
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

public class GameplayUIManager : SceneSingleton<GameplayUIManager>
{     
    [SerializeField] TMPro.TextMeshProUGUI _scoreCounter;
    [SerializeField] TMPro.TextMeshProUGUI _livesCount;

    int currentScore;
    
    public void IncreasePlayerScore(int value)
    {
        currentScore += value;
        _scoreCounter.text = currentScore.ToString();
    }

    public void DecreasePlayerLives()
    {

    }
}
