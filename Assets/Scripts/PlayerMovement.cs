using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player Status")]
    public bool constantMoving; // Variable que permite activar o desactivar el movimiento constante del jugador.
    private bool isDashing; 
    [Header ("Player's Atributes")]
    public float shipVelocity; // Variable que nos permite modificar la velocidad en que se mueve el jugador.
    public float rotationSpeed; // Variable que contiene la velocidad de rotación del jugador.
    public float dashVelocity; // Variable que contiene la velocidad de Dash del jugador.
    private float currentShipVelocity;
    public float dashCooldown;
    public bool isDashOnCooldown;
    [Header ("Player's References")]
    public Rigidbody rbShip; // Variable que contiene el Rigidbody del jugador.
    public GameObject player; // Variable que contiene el GameObject del jugador.
    public GameObject Trails01;
    public GameObject Trails02;
    public GameObject TurboTrails01;
    public GameObject TurboTrails02;
    [Header ("GameManager")]
    public GameManager gm; 

    void Start()
    {
        currentShipVelocity = shipVelocity;
    }

    
    void Update()
    {
        // Actualización que llama a la función ConstantMovement.
        ConstantMovement();
        // Actualización que llama a la función ShipRotation.
        ShipRotation();
        // Actualización que llama a la función Dash.
        Dash();
        DashTrails();
    }

    // Función para mover al jugador constantemente si es que es verdadero el bool "constantMoving". Si el bool es falso, el jugador se detiene.
    public void ConstantMovement() 
    {
        if (constantMoving)
        {
            rbShip.velocity = transform.forward * currentShipVelocity;
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
        if (Input.GetKeyDown(KeyCode.Z) && !isDashing && !isDashOnCooldown)
        {
            StartCoroutine(DashCoroutine());
            StartCoroutine(DashCooldown());
        }
    }

    public void DashTrails()
    {
       if(isDashing)
       {
          //Trails01.SetActive(false);
          //Trails02.SetActive(false);
          TurboTrails01.SetActive(true);
          TurboTrails02.SetActive(true);
       }
       if(!isDashing)
       {
          //Trails01.SetActive(true);
          //Trails02.SetActive(true);
          TurboTrails01.SetActive(false);
          TurboTrails02.SetActive(false);
       }
    }

    private IEnumerator DashCoroutine()
    {
        isDashing = true;
        
        while(currentShipVelocity < shipVelocity * 2)
        {
            currentShipVelocity += 0.5f;
            yield return null;
        }

        // esperar X segundos y luego volver a velocidad normal
        yield return new WaitForSeconds(1f);

        while(currentShipVelocity > shipVelocity)
        {
            currentShipVelocity -= 0.3f;
            yield return null;
        }

        isDashing = false;
    }

    private IEnumerator DashCooldown()
    {
       isDashOnCooldown = true;
       
       yield return new WaitForSeconds(dashCooldown);

       isDashOnCooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killzone")
        {
            gm.SubtractLives();
            UnityGamingServices.AnalyticsManager.RegistrarDanioJugador(1, "Kilzone");
            player.transform.position = new Vector3 (0,4.5f,0);
            
        }

    }
}
