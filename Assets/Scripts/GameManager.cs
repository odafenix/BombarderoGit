using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class GameManager : MonoBehaviour
{
    public TMP_Text ammo;  // Texto que indica la cantidad de munición en el canvas.
    public TMP_Text lives; // Texto que indica la cantidad de vidas en el canvas.
    public TMP_Text coins; // Texto que indica la cantidad de monedas en el canvas.
    public int ammoCounter; // Variable que contiene la cantidad de munición.
    public int coinsCounter; // Variable que contiene la cantidad de monedas.
    public int livesCounter; // Variable que contiene la cantidad de vidas.
    public int ammoPackage; // Variable que contiene la cantidad de munición que se puede comprar, o, conseguir.
    public int maxAmmo; // Variable que indica el valor máximo de munición.
    public int maxLives; // Variable que indica el valor máximo de vidas.
    public int ammoValue; // Variable que indica el precio de compra de munición.
    public int livesValue; // Variable que indica el precio de compra de vidas.
    public GameObject soldOutAmmo; // GameObject que contiene la imagen SoldOut de munición.
    public GameObject soldOutLives; // GameObject que contiene la imagen SoldOut de vidas.
    public GameObject noCoinsPopup; // GameObkect que contiene el botón de NoCoinsPopup.
    public PlayerMovement pm; 

    void Start()
    {
        
    }

    
    void Update()
    {
        // Actualización de textos en canvas: Munición; Monedas; y Vidas respectivamente.
        ammo.text = ammoCounter.ToString();
        coins.text = coinsCounter.ToString();
        lives.text = livesCounter.ToString();
        
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
        
    }

    // Función que sustrae munición al contador de munición.
    public void SubtractAmmo()
    {
        ammoCounter = ammoCounter - 1;
    }
    
    // Función que añade monedas al contador de monedas.
    public void AddCoins()
    {
        coinsCounter = coinsCounter + 1;
    }

    // Función que permite comprar munición, añadiendola al contador de munición y restando el valor de la munición al total de monedas, si tenemos la cantidad de monedas necesarias y no hemos excedido el máximo de munición.
    public void AddAmmo()
    {
        if (ammoCounter < maxAmmo && coinsCounter >= ammoValue)
        {
        coinsCounter = coinsCounter - ammoValue;
        ammoCounter = ammoCounter + ammoPackage;
        }
        
        
    }
    
    // Función que permite comprar vidas, añadiendola al contador de vidas y restando el valor de las vidas al total de monedas, si tenemos la cantidad de monedas necesarias y no hemos excedido el máximo de vidas.
    public void AddLives()
    {
       if (livesCounter < maxLives && coinsCounter >= livesValue)
       {
       coinsCounter = coinsCounter - livesValue;
       livesCounter = livesCounter + 1;
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
}
