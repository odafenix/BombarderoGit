using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(DestroyParticles()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyParticles()
    {
       yield return new WaitForSeconds(2);
       Destroy(this.gameObject);
    }
}
