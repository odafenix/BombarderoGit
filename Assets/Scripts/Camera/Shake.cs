using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public GameObject camerashake;
    
    // Usando referencias de:
    // https://www.youtube.com/watch?v=O2Pg8e2xwzg&ab_channel=LumidiDeveloper


    // Corrutina para que se haga por X cantidad de segundos el efecto CameraShake.
    IEnumerator CameraShake()
    {
        camerashake.SetActive(true);

        yield return new WaitForSeconds(1);

        camerashake.SetActive(false);

    }
}
