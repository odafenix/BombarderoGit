using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    
    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destructible")
        {
            Destroy(other.gameObject);
            Destroy(gameObject); 
            
        }

        else
        {
            Destroy(gameObject);
        }

    }

    
}
