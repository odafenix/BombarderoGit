using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
     // Usando referencias de:
     // https://answers.unity.com/questions/857444/simple-npc-ai-using-nav-mesh.html
     public Transform[] Navs; // Array que contiene los tranform de los multiples destinos del NavMeshAgent.
     NavMeshAgent agent; // NavMeshAgent perteneciente al contentedor del script.
 
     void Start () 
     {
         // Al iniciar se consigue el componente de NavMeshAgent.
         agent = GetComponent<NavMeshAgent>(); 
     }
     
     void Update () 
     {
         // Si la velocidad del Agente es 0, entonces busca un nuevo destino.
         if (agent.velocity.magnitude == 0f)
         {
             agent.SetDestination(Navs[Random.Range(0, Navs.Length)].position);
         }
     }
}

