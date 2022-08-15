using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBullet : MonoBehaviour
{
    GameManager gm;
    public AudioManager am; // Variable que nos permite acceder a la clase AudioManager.
    Shake shake;
    public ParticleSystem particles;
    


    
    void Start()
    {
        // Funci�n que asigna a la variable "gm" el componente GameManager.
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        am = GameObject.FindGameObjectWithTag("AM").GetComponent<AudioManager>();
        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<Shake>();
        // particles = GameObject.FindGameObjectWithTag("Particles").GetComponent<GameObject>();

        StartCoroutine(AttackDestroyItself());

    }


    // Función que detecta la colisión del objeto con otro. Si, el objeto con el que colisiona, tiene el tag "Player", se ejecuta la funci�n "Substract Lives", restándole una vida al jugador .Si no, solo se destruye el objeto portador del código.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            am.PlayPlayerDamage();
            Instantiate(particles, transform.position, Quaternion.identity);
            gm.SubtractLives();
            shake.StartCoroutine("CameraShake");
            Destroy(gameObject);
            UnityGamingServices.AnalyticsManager.RegistrarDanioJugador(1, this.gameObject.name);

        }
        
    }

    // Corrutina que hace destruir al objeto al terminar.
    private IEnumerator AttackDestroyItself()
    {
       yield return new WaitForSeconds(2);
       Destroy(this.gameObject);
  
    }

    
}
