using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sourceBuy;
    public AudioSource sourceChangeBomb;
    public AudioSource sourceDash;    
    public AudioSource sourcePlayerAttack;
    public AudioSource sourcePlayerDamage;
    

    public AudioClip clipBuy;
    public AudioClip clipChangeBomb;
    public AudioClip clipDash;    
    public AudioClip clipPlayerAttack;
    public AudioClip clipPlayerDamage;
    

    public Vector2 pitchRange;

    public void PlayBuy()
    {
        sourceBuy.clip = clipBuy;
        sourceBuy.Play();
    }

    public void PlayChangeBomb() //FALTAAAAAAAAAA
    {
        sourceChangeBomb.clip = clipChangeBomb;
        sourceChangeBomb.Play();
    }

    public void PlayDash()
    {
        sourceDash.clip = clipDash;
        sourceDash.Play();
    }
     
    public void PlayPlayerAttack()
    {
        sourcePlayerAttack.clip = clipPlayerAttack;
        sourcePlayerAttack.pitch = Random.Range(pitchRange.x, pitchRange.y);
        sourcePlayerAttack.Play();
    }

    public void PlayPlayerDamage()
    {
        sourcePlayerDamage.clip = clipPlayerDamage;
        sourcePlayerDamage.pitch = Random.Range(pitchRange.x, pitchRange.y);
        sourcePlayerDamage.Play();
    }
       
}
