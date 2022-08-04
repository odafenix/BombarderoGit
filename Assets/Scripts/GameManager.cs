using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class GameManager : MonoBehaviour
{
    public TMP_Text ammo;
    public int ammoCounter;
    public int ammoPackage;

    void Start()
    {
        
    }

    
    void Update()
    {
        ammo.text = ammoCounter.ToString();
    }

    public void SubtractAmmo()
    {
        ammoCounter = ammoCounter - 1;
    }

    public void AddAmmo()
    {
        ammoCounter = ammoCounter + ammoPackage;
    }
}
