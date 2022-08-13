using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform target;
    public Transform enemy;

    public GameObject spawner;
    public GameObject bullet;
    GameObject balaClon;
    public float forceBullet;
    public bool inZone;

    public float playerDistance;
    public float visionRange;

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        //Que dispare al player cuando est� en su rango de visi�n
        playerDistance = Vector2.Distance(target.position, enemy.position);
        if (playerDistance < visionRange)
        {

            if (inZone == false)
            {
                inZone = true;
                StartCoroutine("CadaXTiempoDisparo");
            }

        }
        else
        {
            inZone = false;
        }


        
        // Funci�n para que la torreta siga la posici�n del jugador.
        transform.LookAt(target);


    }


    // Funci�n que hace que se instancie la bala y salga disparada en direcci�n al jugador.
    private void Shoot()
    {
        balaClon = Instantiate(bullet, spawner.GetComponent<Transform>().position, Quaternion.identity);        
        balaClon.GetComponent<Rigidbody>().velocity = transform.forward * forceBullet;
        balaClon.transform.LookAt(target);
        UnityGamingServices.AnalyticsManager.RegistrarDanioJugador(1, this.gameObject.name);
    }

    
    // Corrutina para que la bala salga disparada cada X segundos.
    IEnumerator CadaXTiempoDisparo()
    {
        while (inZone == true)
        {
            Shoot();
            yield return new WaitForSeconds(1.5f);
        }

        yield break;

    }
}
