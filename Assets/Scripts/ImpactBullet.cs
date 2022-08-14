using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBullet : MonoBehaviour
{
    GameManager gm;
    Shake shake;
    public ParticleSystem particles;
    


    // Start is called before the first frame update
    void Start()
    {
        // Funci�n que asigna a la variable "gm" el componente GameManager.
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<Shake>();
        // particles = GameObject.FindGameObjectWithTag("Particles").GetComponent<GameObject>();

        StartCoroutine(AttackDestroyItself());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Función que detecta la colisión del objeto con otro. Si, el objeto con el que colisiona, tiene el tag "Player", se ejecuta la funci�n "Substract Lives", restándole una vida al jugador .Si no, solo se destruye el objeto portador del código.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            gm.SubtractLives();
            shake.StartCoroutine("CameraShake");
            Destroy(gameObject);
            UnityGamingServices.AnalyticsManager.RegistrarDanioJugador(1, this.gameObject.name);

        }
        
    }

    private IEnumerator AttackDestroyItself()
    {
       yield return new WaitForSeconds(2);
       Destroy(this.gameObject);
  
    }

    
}
