using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool constantMoving; //Variable que permite activar o desactivar el movimiento constante de la nave.
    public float shipVelocity; //Variable que nos permite modificar la velocidad en que se mueve la nave.
    public Rigidbody rbShip;
    public GameObject player;
    public float rotationSpeed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        ConstantMovement();
        ShipRotation();
    }

    public void ConstantMovement() //Método para mover la nave constantemente si es que es verdadero el bool "constantMoving".
    {
        if (constantMoving)
        {
            // rbShip.AddForce(new Vector3(shipVelocity * Time.deltaTime, 0, 0));
            rbShip.velocity = transform.forward * shipVelocity;
        }

        else
        {
            rbShip.velocity = new Vector3 (0,0,0);
        }
    }

    public void ShipRotation() //Método para rotar la nave en sentido horario y antihorario.
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
}
