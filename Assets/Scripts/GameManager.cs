using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

using UnityGamingServices;


public class GameManager : MonoBehaviour
{
    [Header ("UI Texts")]
    public TMP_Text ammo;  // Texto que indica la cantidad de munición en el canvas.
    public TMP_Text lives; // Texto que indica la cantidad de vidas en el canvas.
    public TMP_Text coins; // Texto que indica la cantidad de monedas en el canvas.
    public TMP_Text objectives; // Texto que indica la cantidad de objetivos a destruir en el canvas.

    [Header ("UI Counters")]
    public int ammoCounter; // Variable que contiene la cantidad de munición.
    public int coinsCounter; // Variable que contiene la cantidad de monedas.
    public int livesCounter; // Variable que contiene la cantidad de vidas.
    public int objectivesCounter; // Variable que contiene la cantidad de objetivos destruidos.

    [Header ("UI Max Counters")]
    public int ammoPackage; // Variable que contiene la cantidad de munición que se puede comprar, o, conseguir.
    public int maxAmmo; // Variable que indica el valor máximo de munición.
    public int maxLives; // Variable que indica el valor máximo de vidas.
    public int maxObjectives; // Variable que indica el valor máximo de objetivos a destruir.

    [Header ("UI Values")]
    public int ammoValue; // Variable que indica el precio de compra de munición.
    public int livesValue; // Variable que indica el precio de compra de vidas.

    [Header ("UI GameObjects")]
    public GameObject soldOutAmmo; // GameObject que contiene la imagen SoldOut de munición.
    public GameObject soldOutLives; // GameObject que contiene la imagen SoldOut de vidas.
    public GameObject noCoinsPopup; // GameObject que contiene el botón de NoCoinsPopup.
    public GameObject shopButton; // GameObject que contiene el botón de ShopButton.
    public GameObject livesButton; // GameObject que contiene el botón de ShopButton.
    public GameObject ammoButton; // GameObject que contiene el botón de ShopButton.

    [Header ("Scripts")]
    public PlayerMovement pm;
    public bool isShopActive;
    public bool isLivesShopActive; 
    public bool isAmmoShopActive;  

    private async void Start()
        {


            await TaskUtils.WaitUntil(()=>RemoteSettingsManager.IsReady);
            maxLives = RemoteSettingsManager.GetConfig(RemoteSettingsConstants.MaxLives, maxLives);

            await TaskUtils.WaitUntil(()=>RemoteSettingsManager.IsReady);
            livesCounter = RemoteSettingsManager.GetConfig(RemoteSettingsConstants.CurrentLives, livesCounter);

            await TaskUtils.WaitUntil(()=>RemoteSettingsManager.IsReady);
            maxAmmo = RemoteSettingsManager.GetConfig(RemoteSettingsConstants.MaxAmmo, maxAmmo);

            await TaskUtils.WaitUntil(()=>RemoteSettingsManager.IsReady);
            ammoCounter = RemoteSettingsManager.GetConfig(RemoteSettingsConstants.CurrentAmmo, ammoCounter);

            await TaskUtils.WaitUntil(()=>RemoteSettingsManager.IsReady);
            isShopActive = RemoteSettingsManager.GetConfig(RemoteSettingsConstants.IsShopActive, isShopActive);

            await TaskUtils.WaitUntil(()=>RemoteSettingsManager.IsReady);
            isLivesShopActive = RemoteSettingsManager.GetConfig(RemoteSettingsConstants.IsLivesShopActive, isLivesShopActive);

            await TaskUtils.WaitUntil(()=>RemoteSettingsManager.IsReady);
            isAmmoShopActive = RemoteSettingsManager.GetConfig(RemoteSettingsConstants.IsAmmoShopActive, isAmmoShopActive);
            
        
        }

    
    void Update()
    {
        // Actualización de textos en canvas: Munición; Monedas; Vidas; y Objetivos respectivamente.
        ammo.text = ammoCounter.ToString();
        coins.text = coinsCounter.ToString();
        lives.text = livesCounter.ToString();
        objectives.text = objectivesCounter.ToString() + "/" + maxObjectives.ToString();


        if(!isShopActive)
        {
           shopButton.SetActive(false);
        }

        if(isShopActive)
        {
           shopButton.SetActive(true);
        }

        if(!isAmmoShopActive)
        {
           ammoButton.SetActive(false);
        }

        if(isAmmoShopActive)
        {
           ammoButton.SetActive(true);
        }

        if(!isLivesShopActive)
        {
           livesButton.SetActive(false);
        }

        if(isLivesShopActive)
        {
           livesButton.SetActive(true);
        }

        
        
        // Actualización que señala que la imagen de SoldOut de munición se encuentra desactivada cuando la munición máxima se ha alcanzado.
        if (ammoCounter < maxAmmo)
        {
        soldOutAmmo.SetActive(false);
        }

        // Actualización que señala que la imagen de SoldOut de vidas se encuentra desactivada cuando las vidas máximas se han alcanzado.
        if (livesCounter < maxLives)
        {
       soldOutLives.SetActive(false);
        }
        
        // Actualización que limita el valor de munición maxima a 100 en caso de excederse al comprar.
        if (ammoCounter > 100)
        {
            ammoCounter = 100;
        }

        if (ammoCounter >= maxAmmo)
        {
          soldOutAmmo.SetActive(true);
        }

        if (livesCounter >= maxLives)
        {
          soldOutLives.SetActive(true);
        }

        Victory();
        GameOver();
        
    }

    // Función que sustrae munición al contador de munición.
    public void SubtractAmmo()
    {
        ammoCounter = ammoCounter - 1;
    }

    public void SubtractLives()
    {
        livesCounter = livesCounter - 1;
    }
    
    // Función que añade monedas al contador de monedas.
    public void AddCoins()
    {
        coinsCounter = coinsCounter + 1;
    }

    // Función que añade objetivos al contador de objetivos destruidos.
    public void AddObjectives()
    {
        objectivesCounter = objectivesCounter + 1;
    }

    // Función que permite comprar munición, añadiendola al contador de munición y restando el valor de la munición al total de monedas, si tenemos la cantidad de monedas necesarias y no hemos excedido el máximo de munición.
    public void AddAmmo()
    {
        if (ammoCounter < maxAmmo && coinsCounter >= ammoValue)
        {
        coinsCounter = coinsCounter - ammoValue;
        ammoCounter = ammoCounter + ammoPackage;
        UnityGamingServices.AnalyticsManager.RegistrarCompraJugador(ammoPackage, "Ammo Package");
        }
        
        
    }
    
    // Función que permite comprar vidas, añadiendola al contador de vidas y restando el valor de las vidas al total de monedas, si tenemos la cantidad de monedas necesarias y no hemos excedido el máximo de vidas.
    public void AddLives()
    {
       if (livesCounter < maxLives && coinsCounter >= livesValue)
       {
       coinsCounter = coinsCounter - livesValue;
       livesCounter = livesCounter + 1;
       UnityGamingServices.AnalyticsManager.RegistrarCompraJugador(1, "Lives Package");
       }
       
    }

    // Función que activa el "popup noCoins" si no tenemos la cantidad de monedas necesarias para comprar munición.
    public void NoCoinsForAmmo()
    {
        if (coinsCounter < ammoValue)
        {
        noCoinsPopup.SetActive(true);
        }
    }

    // Función que activa el "popup noCoins" si no tenemos la cantidad de monedas necesarias para comprar vidas.
    public void NoCoinsForLives()
    {
        if (coinsCounter < livesValue)
        {
        noCoinsPopup.SetActive(true);
        }
    }

    // Función que desactiva el movimiento constante del jugador al abrir la tienda.
    public void ShopOpen()
    {
        pm.constantMoving = false;
    }

    // Función que activa el movimiento constante del jugador al cerrar la tienda.
    public void ShopClose()
    {
        pm.constantMoving = true;
    }

        //NO CORRUTINA 
    public void ShowMessageIn5Seconds()
    {
        Invoke(nameof(MostrarMensaje),5);
    }

    public void MostrarMensaje()
    {
        UnityEngine.Debug.Log("Mensaje");
    }
    

    //AAAA
    public void GameOver()
    {
        if (livesCounter <= 0)
        {
          livesCounter = 0;
          SceneManager.LoadScene("GameOver");
          UnityGamingServices.AnalyticsManager.RegistrarNavegacion("GameOverScreen");
        }
        
    }

     //AAA
     public void Victory()
    {
        if (objectivesCounter >= maxObjectives)
        {
           SceneManager.LoadScene("Victory");
           UnityGamingServices.AnalyticsManager.RegistrarNavegacion("VictoryScreen");
           objectivesCounter = 0;
        }

    }
}


