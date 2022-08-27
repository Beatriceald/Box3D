using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int Health = 10;

    public bool Invulnerable = false;

    public Gloves Gloves;

    // пока нет звуков
    //public AudioSource TakeDamage;

    public UnityEvent EventOnTakeDamage;

    public void TakeDamage(int damageValue) {
        if (Invulnerable == false) {
            Health -= damageValue;
            if (Health <= 0) {
                Health = 0;
                Defeat();
            }
            Invulnerable = true;
            Invoke("StopInvulnerable", Gloves.InvulnerableHealthTime);
            EventOnTakeDamage.Invoke();
        }
    }

    public void StartInvulnerable() {
        Invulnerable = true;
    }

    public void StopInvulnerable() {
        Invulnerable = false;
    }

    void Defeat() {
        Debug.Log("Поражение");
    }
}
