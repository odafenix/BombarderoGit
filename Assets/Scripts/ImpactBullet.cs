using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBullet : MonoBehaviour
{
    GameManager gm;
    Shake shake;
    


    // Start is called before the first frame update
    void Start()
    {
        // Funci�n que asigna a la variable "gm" el componente GameManager.
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<Shake>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Funci�n que detecta la colisi�n del objeto con otro. Si, el objeto con el que colisiona, tiene el tag "Player", se ejecuta la funci�n "Substract Lives", rest�ndole una vida al jugador .Si no, solo se destruye el objeto portador del c�digo.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.SubtractLives();
            shake.StartCoroutine("CameraShake");
            Destroy(gameObject);
            UnityGamingServices.AnalyticsManager.RegistrarDanioJugador(1, this.gameObject.name);

        }

        /*
        {
            Destroy(gameObject);
        }
        */

    }

    
}
