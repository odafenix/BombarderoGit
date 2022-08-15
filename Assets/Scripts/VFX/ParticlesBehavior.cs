using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehavior : MonoBehaviour
{
    
    void Start()
    {
       // Inicio de la corrutina de destruir particulas.
       StartCoroutine(DestroyParticles()); 
    }


    // Corrutina que destruye las particulas.
    private IEnumerator DestroyParticles()
    {
       yield return new WaitForSeconds(2);
       Destroy(this.gameObject);
    }
}
