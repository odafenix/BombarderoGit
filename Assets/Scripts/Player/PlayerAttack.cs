using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header ("Bomb Atributes")]
    public GameObject spawnerBomb; // Variable que contiene el GameObject pivote de spawn de las bombas.
    public GameObject spawnerExtraBomb01; // Variable que contiene el GameObject pivote de spawn de las bombas.
    public GameObject spawnerExtraBomb02; // Variable que contiene el GameObject pivote de spawn de las bombas.
    public GameObject prefabBomb; // Variable que contiene el GameObject prefab de bombas.
    public Rigidbody rbPrefabBomb; // Variable que contiene el Rigidbody del prefab de bombas.
    public float speedBomb; // Variable que contiene la velocidad del lanzamiento de bombas.
    public bool areExtraWeaponsActive; // Variable que contiene el booleano que activa las armas extras.
    [Header ("GameManager")]
    public GameManager gm; // Variable que nos permite acceder a la clase GameManager.
    
    
    void Update()
    {
        // Actualización que llama a la función Attack.
        Attack();
    }



    // Función que instancia el prefab de bomba, al presionar la tecla "espacio", en el pivote de spawn, con la velocidad delantera de speedBomb, y a la vez llama a la función SubtractAmmo de la clase GameManager.
    void Attack()
    {
        if (Input.GetKeyDown("space") && gm.ammoCounter > 0)
        {            
            Rigidbody bomb;
            bomb = Instantiate(rbPrefabBomb, spawnerBomb.transform.position, spawnerBomb.transform.rotation);
            bomb.velocity = transform.TransformDirection(Vector3.forward * speedBomb);
            gm.SubtractAmmo();

            if(areExtraWeaponsActive == true)
            {
               Rigidbody bomb01;
               bomb01 = Instantiate(rbPrefabBomb, spawnerExtraBomb01.transform.position, spawnerExtraBomb01.transform.rotation);
               bomb01.velocity = transform.TransformDirection(Vector3.forward * speedBomb);

               Rigidbody bomb02;
               bomb02 = Instantiate(rbPrefabBomb, spawnerExtraBomb02.transform.position, spawnerExtraBomb02.transform.rotation);
               bomb02.velocity = transform.TransformDirection(Vector3.forward * speedBomb);
            }

        }
    }
}
