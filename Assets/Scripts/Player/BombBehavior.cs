using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{

    public GameManager gm;   // Variable que nos permite acceder a la clase GameManager.
    public AudioManager am; // Variable que nos permite acceder a la clase AudioManager.

    public ParticleSystem particles; // Variable que nos permite acceder a las particulas.

    void Start()
    {
       // Función que asigna a la variable "gm" el componente GameManager.
       gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
       am = GameObject.FindGameObjectWithTag("AM").GetComponent<AudioManager>();
    }


    // Función que detecta la colisión del objeto con otro. Si, el objeto con el que colisiona, tiene el tag "Destructible", entonces, se llama la función AddCoins de GM, se destruye el objeto portador del código, y el objeto con el tag "Destructible". Si no, solo se destruye el objeto portador del código.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destructible")
        {
            am.PlayPlayerAttack(); // Audio PlayerAttack
            gm.AddCoins();
            gm.AddObjectives();
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject); 
            
        }

        else
        {
            Destroy(gameObject);
        }

    }

    
}
