using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject spawnerBomb;
    public GameObject prefabBomb;
    public Rigidbody rbPrefabBomb;
    public float speedBomb;
    public GameManager gm;

    void Start()
    {
        
    }

    
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown("space"))
        {
            //GameObject bomb;
            //bomb = Instantiate(prefabBomb, spawnerBomb.transform.position, spawnerBomb.transform.rotation);
            Rigidbody bomb;
            bomb = Instantiate(rbPrefabBomb, spawnerBomb.transform.position, spawnerBomb.transform.rotation);
            bomb.velocity = transform.TransformDirection(Vector3.forward * speedBomb);
            gm.SubtractAmmo();

        }
    }
}
