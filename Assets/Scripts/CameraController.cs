using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform playerPosition;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        cameraPosition.transform.position = playerPosition.transform.position;
    }
}
