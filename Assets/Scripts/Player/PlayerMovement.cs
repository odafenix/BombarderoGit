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
    private float currentShipVelocity; // Variable que contiene la velocidad actual del jugador.
    public float dashCooldown; // Variable que contiene el tiempo de cooldown del Dash.
    public bool isDashOnCooldown;
    [Header ("Player's References")]
    public Rigidbody rbShip; // Variable que contiene el Rigidbody del jugador.
    public GameObject player; // Variable que contiene el GameObject del jugador.
    public GameObject Trails01; // Variable que contiene el trail.
    public GameObject Trails02; // Variable que contiene el trail.
    public GameObject TurboTrails01; // Variable que contiene el trail.
    public GameObject TurboTrails02; // Variable que contiene el trail.
    [Header ("GameManager")]
    public GameManager gm; // Variable que nos permite acceder a la clase GameManager.
    public AudioManager am; // Variable que nos permite acceder a la clase AudioManager.

    
    void Start()
    {
        currentShipVelocity = shipVelocity;
    }

    
    void Update()
    {
        // Actualización que llama a la función ShipRotation.
        ShipRotation();

        // Actualización que llama a la función Dash.
        Dash();

        // Actualización que llama a la función DashTrail.
        DashTrails();
    }

    private void FixedUpdate()
    {
        // Actualización que llama a la función ConstantMovement.
        ConstantMovement();
        
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
            am.PlayDash(); // Audio Dash
            StartCoroutine(DashCoroutine());
            StartCoroutine(DashCooldown());
        }
    }

    // Funcipon que activa y desactiva los trails turbo.
    public void DashTrails()
    {
       if(isDashing)
       {
          TurboTrails01.SetActive(true);
          TurboTrails02.SetActive(true);
       }
       if(!isDashing)
       {
          TurboTrails01.SetActive(false);
          TurboTrails02.SetActive(false);
       }
    }

    // Corrutina que contiene los elementos del Dash.
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

    // Corrutina que define el cooldown del Dash
    private IEnumerator DashCooldown()
    {
       isDashOnCooldown = true;
       
       yield return new WaitForSeconds(dashCooldown);

       isDashOnCooldown = false;
    }

    // Muerte del player por salir del mapa.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killzone")
        {
            am.PlayPlayerDamage();
            gm.SubtractLives();
            UnityGamingServices.AnalyticsManager.RegistrarDanioJugador(1, "Kilzone");
            player.transform.position = new Vector3 (0,4.5f,0);
            
        }

    }
}
