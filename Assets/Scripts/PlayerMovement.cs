using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool constantMoving; // Variable que permite activar o desactivar el movimiento constante del jugador.
    public float shipVelocity; // Variable que nos permite modificar la velocidad en que se mueve el jugador.
    public Rigidbody rbShip; // Variable que contiene el Rigidbody del jugador.
    public GameObject player; // Variable que contiene el GameObject del jugador.
    public float rotationSpeed; // Variable que contiene la velocidad de rotación del jugador.
    public float dashVelocity; // Variable que contiene la velocidad de Dash del jugador.
    public GameManager gm; 
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // Actualización que llama a la función ConstantMovement.
        ConstantMovement();
        // Actualización que llama a la función ShipRotation.
        ShipRotation();
        // Actualización que llama a la función Dash.
        Dash();
    }

    // Función para mover al jugador constantemente si es que es verdadero el bool "constantMoving". Si el bool es falso, el jugador se detiene.
    public void ConstantMovement() 
    {
        if (constantMoving)
        {
            rbShip.velocity = transform.forward * shipVelocity;
        }

        else
        {
            rbShip.velocity = new Vector3 (0,0,0);
        }
    }

    // Función para rotar al jugador en sentido horario y antihorario.
    public void ShipRotation() 
    {
        if (Input.GetKey("left"))
        {
            player.transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            player.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    // Función para incrementar la velocidad del jugador brevemente usando la tecla "Z".
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rbShip.velocity = transform.forward * dashVelocity;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killzone")
        {
            gm.SubtractLives();
            player.transform.position = new Vector3 (0,4.5f,0);
            
        }

    }
}
