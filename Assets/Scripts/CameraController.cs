using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    [Header ("Positions")]
    public Transform cameraPosition; // Variable que indica el valor Transform de la cámara principal.      
    public Transform playerPosition; // Variable que indica el valor Transform del jugador.  

    private void LateUpdate()
    {
        // Actualización que hace a la cámara seguir la posición del jugador.
        if (cameraPosition == null || playerPosition == null) 
        {   // no hacer nada, ya que no hay objeto que mover
            return; 
        }

        cameraPosition.transform.position = playerPosition.transform.position;
    }
}
