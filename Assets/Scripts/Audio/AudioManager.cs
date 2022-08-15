using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Variables AudioSource
    public AudioSource sourceBuy;
    public AudioSource sourceDash;    
    public AudioSource sourcePlayerAttack;
    public AudioSource sourcePlayerDamage;
    

    // Variables AudioClip
    public AudioClip clipBuy;
    public AudioClip clipDash;    
    public AudioClip clipPlayerAttack;
    public AudioClip clipPlayerDamage;
    

    // Variable que permite modificar el pitch.
    public Vector2 pitchRange;

    // Funciones para reproducir SFX.
    public void PlayBuy()
    {
        sourceBuy.clip = clipBuy;
        sourceBuy.Play();
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
