using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactBullet : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        // Funci�n que asigna a la variable "gm" el componente GameManager.
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
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
            //camerashake            
            Destroy(gameObject);

        }

        /*else
        {
            Destroy(gameObject);
        }*/

    }
}
