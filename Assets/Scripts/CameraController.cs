using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition; // Variable que indica el valor Transform de la cámara principal.      
    public Transform playerPosition; // Variable que indica el valor Transform del jugador.

    
    void Start()
    {
        
    }

    void Update()
    {
        // Actualización que hace a la cámara seguir la posición del jugador.
        cameraPosition.transform.position = playerPosition.transform.position;
    }
}
