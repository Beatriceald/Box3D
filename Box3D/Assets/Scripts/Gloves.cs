using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gloves : MonoBehaviour {
    public Animator GlovesAnimator;

    public PlayerHealth PlayerHealth;

    public float InvulnerableHealthTime = 0.5f;
    public float InvulnerableBlockingTime;

    public AudioSource HitSound;


    public void Blocking() {

        PlayerHealth.StartInvulnerable();
        GlovesAnimator.SetTrigger("Blocking");
        Invoke("StopHealthInvulnerable", InvulnerableBlockingTime);
    }

    public void RightPunch() {

        //PlayerHealth.StartInvulnerable();
        GlovesAnimator.SetTrigger("Right");
        Invoke("PlayHit", 0.15f);
        //Invoke("StopHealthInvulnerable", InvulnerableHealthTime);
    }

    public void LeftPunch() {
        // PlayerHealth.StartInvulnerable();
        GlovesAnimator.SetTrigger("Left");
        Invoke("PlayHit", 0.15f);
        // Invoke("StopHealthInvulnerable", InvulnerableHealthTime);
    }

    public void StopHealthInvulnerable() {
        PlayerHealth.StopInvulnerable();
    }

    private void PlayHit() {
        HitSound.Play();
    }
}
